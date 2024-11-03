#region usings
using Application.DTOs.OTP;
using Application.DTOs.User.UserLogInDTO;
using Application.DTOs.User.UserRegisterDTO;
using Application.Services.Interface.User;
using Application.Utilities.Generators;
using Application.Utilities.OTP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

#endregion

namespace Sample_WebApi_For_Blazort.Controllers;

// این کنترلر مسئول مدیریت عملیات ارسال پیامک و درخواست‌های مرتبط است
[Route("[controller]")]
[ApiController]
public class OTPController : ControllerBase
{

    private readonly string username;
    private readonly string password;
    private readonly string from;
    private readonly string apiUrl;

    private readonly IUserService userService;

    public OTPController(IConfiguration configuration, IUserService userService)
    {
        // گرفتن مقادیر از appsettings.json
        username = configuration["SMSSettings:Username"];
        password = configuration["SMSSettings:Password"];
        from = configuration["SMSSettings:From"];
        apiUrl = configuration["SMSSettings:ApiUrl"];
        this.userService = userService;
    }


    [HttpPost("[Action]")]
    public async Task<ActionResult<OTPResponse>> SendOtp(string to, bool? isFlash = false)
    {
        OTPResponse otpResponse = new OTPResponse();

        try
        {
            // تولید OTP
            var otpCode = OTPGenerator.GenerateRandomOTP();

            // ذخیره OTP به همراه زمان انقضا
            var otpModel = new OtpModel
            {
                PhoneNumber = to,
                OtpCode = otpCode,
                ExpiryTime = DateTime.Now.AddMinutes(2) // زمان انقضا 1 دقیقه
            };

            OtpStorage.SaveOtp(otpModel);

            // پیام برای ارسال
            var text = $"  کد تایید آکادمی فوتبال ایران : {otpCode}";


            // ارسال پیامک
            #region Send SMS

            var client = new RestClient(apiUrl);
            // ساختن درخواست و افزودن پارامترهای Query String
            var restRequest = new RestRequest();
            restRequest.AddQueryParameter("username", username);
            restRequest.AddQueryParameter("password", password);
            restRequest.AddQueryParameter("to", to);
            restRequest.AddQueryParameter("from", from);
            restRequest.AddQueryParameter("text", $"{text} - کد تایید شما: {otpCode}");
            restRequest.AddQueryParameter("isflash", isFlash.ToString().ToLower());

            // ارسال درخواست و دریافت پاسخ
            var response = await client.ExecuteAsync(restRequest);
            #endregion

            if (response.IsSuccessful)
            {

                otpResponse.IsSuccess = true;
                otpResponse.ErrorMessage = "ارسال پیامک موفقیت‌آمیز بود";

            }
            else
            {

                otpResponse.IsSuccess = false;
                otpResponse.ErrorMessage = "ارسال پیامک موفقیت‌آمیز نبود. لطفاً مجدداً تلاش کنید";

            }

            return Ok(otpResponse);

        }
        catch (Exception ex)
        {
            // مدیریت خطاها
            otpResponse.IsSuccess = false;
            otpResponse.ErrorMessage = $"خطا در فرآیند ارسال پیامک: {ex.Message}";
            return BadRequest(otpResponse);
        }

    }


    [HttpPost("[Action]")]
    public async Task<ActionResult<UserResultLogInDTO>> VerifyOtp(VerifyOtpModel model)
    {
        // بررسی کد OTP
        var otp = OtpStorage.GetOtp(model.PhoneNumber);


        UserResultLogInDTO userresultlogin = new UserResultLogInDTO();

        if (otp != null && otp.OtpCode == model.OtpCode)
        {
            userresultlogin = await userService.LogInWithPhoneNumber(model.PhoneNumber);

            OtpStorage.RemoveOtp(model.PhoneNumber); // پاک کردن OTP بعد از تایید

            return Ok(userresultlogin);

        }

        return BadRequest(userresultlogin);
    }

    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> VerifyOtpRegister(RegisterVerifyOtpModel model)
    {
        // بررسی کد OTP
        var otp = OtpStorage.GetOtp(model.PhoneNumber);



        UserRegisterDTO userRegisterDTO = new UserRegisterDTO();

        userRegisterDTO.PhoneNumber = model.PhoneNumber;
        userRegisterDTO.FullName = model.FullName;
        userRegisterDTO.Password = model.Password;
        userRegisterDTO.RePassword = model.RePassword;


        if (otp != null && otp.OtpCode == model.OtpCode)
        {


            var result = await userService.Register(userRegisterDTO);

            OtpStorage.RemoveOtp(model.PhoneNumber); // پاک کردن OTP بعد از تایید

            return Ok(result);

        }

        return BadRequest(false);
    }
}






