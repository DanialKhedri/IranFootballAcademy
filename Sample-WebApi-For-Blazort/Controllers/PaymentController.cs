#region usings
using Application.DTOs.Payment;
using Application.Services.Interface.Payment;
using Application.Services.Interface.User;
using Application.Services.Interfaces;
using Domain.Entities.Payment;
using Infrastructure.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Security.Claims;

#endregion


namespace Sample_WebApi_For_Blazort.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IOrderService _orderService;
    private readonly IUserService _userService;

    private string merchant_id;
    private string CallbackUrl;

    public PaymentController(IConfiguration configuration, IPaymentService paymentService, IOrderService orderService, IUserService userService)
    {
        merchant_id = configuration["PaymentSetting:merchant"];
        CallbackUrl = configuration["PaymentSetting:callbackurl"];

        _paymentService = paymentService;
        _orderService = orderService;
        _userService = userService;
    }





    #region Payment

    //Payment Request

    [HttpPost("[Action]")]
    public async Task<ActionResult<PaymentRequestResponse>> PaymentRequestAsync(PaymentRequestInputModel model)
    {

        try
        {

            // تأخیر 100 میلی‌ثانیه (برای شبیه‌سازی یا کنترل بار سیستم)
            await Task.Delay(100);

            #region Rest Api Request

            // URL شروع پرداخت در زرین‌پال، که کاربر پس از تایید پرداخت به این آدرس هدایت می‌شود
            var urlStartPay = "https://www.zarinpal.com/pg/StartPay/";

            // ایجاد یک کلاینت REST برای ارتباط با API زرین‌پال
            var client = new RestClient("https://api.zarinpal.com/pg/v4/payment/request.json");

            // تنظیم درخواست HTTP به عنوان POST و ارائه آدرس درخواست
            var request = new RestRequest("https://api.zarinpal.com/pg/v4/payment/request.json", Method.Post);

            // تنظیم نوع محتوا به صورت JSON
            request.AddHeader("Content-Type", "application/json");

            // ساختن شیء مدل پرداخت و پر کردن فیلدهای لازم
            PaymentRequest pr = new PaymentRequest
            {
                merchant_id = merchant_id, // مرچنت آیدی که از زرین‌پال دریافت کرده‌اید
                amount = model.Amount * 10, // تبدیل مبلغ به ریال (چون مبلغ ورودی فرضا به تومان است)
                callback_url = CallbackUrl + model.OrderId, // آدرس بازگشت پس از پرداخت موفق
                description = "آکادمی فوتبال ایران" // توضیحات مربوط به پرداخت
            };

            // تبدیل شیء مدل پرداخت به فرمت JSON برای ارسال به API
            var serializedData = JsonConvert.SerializeObject(pr);

            // افزودن بدنه درخواست که شامل داده‌های سریالایز شده است
            request.AddParameter("application/json", serializedData, ParameterType.RequestBody);

            // ارسال درخواست به API و دریافت پاسخ از سرور
            var response = await client.ExecuteAsync(request);

            // بررسی اینکه آیا پاسخ از سمت سرور موفقیت‌آمیز بوده است یا خیر
            if (response.IsSuccessful)
            {
                // دی‌سریالایز کردن داده‌های پاسخ به شیء مدل پرداخت
                var deserializeData = JsonConvert.DeserializeObject<PaymentResponse>(response.Content);

                // بررسی کد بازگشتی (100 نشان‌دهنده موفقیت است)
                if (deserializeData.data.code == 100)
                {

                    // اگر موفقیت‌آمیز بود، URL پرداخت و پیام موفقیت بازگشت داده می‌شود 


                    var ps = new PaymentRequestResponse()
                    {
                        Success = 1, // پیام موفقیت
                        Message = "Success For Payment",
                        Url = urlStartPay + deserializeData.data.authority // ساختن لینک پرداخت
                    };

                    return Ok(ps);

                }
            }

            // اگر پاسخ موفقیت‌آمیز نبود، پیام خطا برگردانده می‌شود
            var ps1 = new PaymentRequestResponse() { Success = -1, Message = "عملیات با موفقیت انجام نشد، دوباره تلاش کنید" };

            return Ok(ps1);

            #endregion

        }

        catch (Exception ex)
        {
            // در صورت بروز خطا، پیام خطا و متن استثنا برگردانده می‌شود
            var ps2 = new PaymentRequestResponse() { Success = -1, Message = ex.Message };
            return Ok(ps2);
        }

    }

    #region Payment Request Models
    public class PaymentRequest
    {

        public PaymentRequest()
        {

        }
        public PaymentRequest(string MerchantID, long Amount, string Callback_url, string Description)
        {
            this.merchant_id = MerchantID;
            this.amount = Amount;
            this.callback_url = Callback_url;
            this.description = Description;
        }

        public string merchant_id { get; set; }
        public string? callback_url { get; set; }
        public string description { get; set; }
        public long amount { get; set; }

        #region اختیاری
        public string? OrderId { get; set; }
        public string? Url { get; set; }
        #endregion

        public DataPaymentRequest data { get; set; }
        public List<Errors> errors { get; set; }
        public Response Response { get; set; }
    }
    public class PaymentRequestResponse
    {
        public string? Url { get; set; }

        public int Success { get; set; }
        public string Message { get; set; }

    }
    public class PaymentRequestInputModel
    {

        public long Amount { get; set; }

        public string OrderId { get; set; }


    }
    public class PaymentResponse
    {
        // بخش data که شامل کد و authority است
        public PaymentData data { get; set; }

        // بخش errors که می‌تواند شامل خطاهای احتمالی باشد
        public List<string> errors { get; set; }
    }
    public class PaymentData
    {
        // کد موفقیت یا عدم موفقیت
        public int code { get; set; }

        // authority برای هدایت کاربر به درگاه پرداخت
        public string authority { get; set; }
    }
    #endregion



    //Payment Verify

    [HttpPost("[Action]")]
    public async Task<ActionResult<PaymentVerificationResponse>> PaymentVerificationAsync(PaymentVerificationInputModel model)
    {
        try
        {
            // تأخیر 100 میلی‌ثانیه برای شبیه‌سازی یا مدیریت بار
            await Task.Delay(100);

            #region Rest Api Request

            // ایجاد کلاینت Rest برای API تأییدیه پرداخت
            var client = new RestClient("https://api.zarinpal.com/pg/v4/payment/verify.json");

            // ایجاد درخواست POST برای ارسال داده‌ها به API
            var request = new RestRequest("https://api.zarinpal.com/pg/v4/payment/verify.json", Method.Post);

            // تنظیم هدر برای نوع محتوا به عنوان JSON
            request.AddHeader("Content-Type", "application/json");

            // ساخت شیء تأییدیه پرداخت با استفاده از داده‌های دریافتی از کاربر
            PaymentVerification pv = new PaymentVerification
            {
                merchant_id = merchant_id, // مرچنت آیدی شما
                authority = model.Authority, // کد authority که از زرین‌پال برگشت داده شده است
                amount = model.Amount * 10 // مبلغ پرداخت شده که به ریال تبدیل شده است
            };

            // سریالایز کردن شیء تأییدیه پرداخت به فرمت JSON
            var serializedData = JsonConvert.SerializeObject(pv);

            // افزودن بدنه درخواست که شامل داده‌های سریالایز شده است
            request.AddParameter("application/json", serializedData, ParameterType.RequestBody);

            // ارسال درخواست و دریافت پاسخ از API
            var response = await client.ExecuteAsync(request);

            // بررسی موفقیت پاسخ
            if (response.IsSuccessful)
            {
                // دی‌سریالایز کردن پاسخ به مدل تأییدیه پرداخت
                var deserializeData = JsonConvert.DeserializeObject<PaymentVerification>(response.Content);

                // بررسی کد موفقیت که 100 نشان‌دهنده موفقیت‌آمیز بودن تراکنش است
                if (deserializeData != null && deserializeData.data.code == 100)
                {


                    // در صورت موفقیت، داده‌ها را ذخیره کنید و پیام موفقیت بازگردانید


                    var result = await _orderService.FinalizeOrder(model.OrderId);






                    //DataBase Things



                    return new PaymentVerificationResponse()
                    {


                        //Response
                        Success = 1,
                        ResponseMessage = "پرداخت با موفقیت انجام شد",



                        // Data
                        code = deserializeData.data.code,
                        message = deserializeData.data.message,
                        card_hash = deserializeData.data.card_hash,
                        card_pan = deserializeData.data.card_pan,
                        ref_id = deserializeData.data.ref_id,
                        fee_type = deserializeData.data.fee_type,
                        fee = deserializeData.data.fee,

                    };
                }
                else
                {
                    // مدیریت خطاهای احتمالی و کدهای ناموفق
                    var pv2 = new PaymentVerificationResponse()
                    {

                        Success = -1,
                        //message = "خطا در تأیید پرداخت: " + deserializeData.message,

                    };

                    return Ok(pv2);
                }
            }

            #endregion

            // اگر پاسخ موفق نبود، پیام خطا بازگردانده می‌شود
            var pv3 = new PaymentVerificationResponse()
            {

                Success = -1,
                message = "پاسخ ناموفق از API ",
            };

            return Ok(pv3);

        }
        catch (Exception ex)
        {
            // در صورت بروز خطا، پیام خطا و متن استثنا بازگردانده می‌شود
            var pv4 = new PaymentVerificationResponse()
            {
                Success = -1,
                message = ex.Message,

            };

            return Ok(pv4);

        }
    }

    #region Payment Verification Models

    // مدل ورودی برای تأیید پرداخت
    public class PaymentVerificationInputModel
    {

        public long Amount { get; set; }

        public string Authority { get; set; }

        public int? OrderId { get; set; }


    }

    // مدل اصلی تأیید پرداخت
    public class PaymentVerification
    {

        public PaymentVerification()
        {

        }
        public PaymentVerification(string MerchantID, long Amount, string Authority)
        {
            this.merchant_id = MerchantID;
            this.amount = Amount;
            this.authority = Authority;
        }

        public PaymentVerification(Response response)
        {
            Response = response;
        }

        public string merchant_id { set; get; }
        public long amount { set; get; }
        public string authority { set; get; }

        public Response Response { get; set; }
        public DataPaymentVerification data { get; set; }
        public List<Errors> errors { get; set; }

        public string OrderId { get; set; }

    }

    public class DataPaymentVerification
    {
        public int code { get; set; }
        public string message { get; set; }
        public string card_hash { get; set; }
        public string card_pan { get; set; }
        public long ref_id { get; set; }
        public string fee_type { get; set; }
        public int fee { get; set; }
    }
    // مدل پاسخ تأیید پرداخت
    public class PaymentVerificationResponse
    {

        //Response
        public int Success { get; set; }
        public string ResponseMessage { get; set; }

        //Data
        public int? code { get; set; }
        public string? message { get; set; }
        public string? card_hash { get; set; }
        public string? card_pan { get; set; }
        public long? ref_id { get; set; }
        public string? fee_type { get; set; }
        public int? fee { get; set; }



    }


    public class PaymentVerificationData
    {

        ////Response
        //public int Success { get; set; }
        //public string ResponseMessage { get; set; }

        //Data
        public int code { get; set; }
        public string message { get; set; }
        public string card_hash { get; set; }
        public string card_pan { get; set; }
        public long ref_id { get; set; }
        public string fee_type { get; set; }
        public int fee { get; set; }



    }
    // مدل داده‌های پاسخ تأیید پرداخت


    // مدل پاسخ کلی برای بازگرداندن نتیجه
    public class Response
    {
        public int Success { get; set; }
        public string Message { get; set; }

        public Response(int success, string message)
        {
            Success = success;
            Message = message;
        }

    }

    #endregion



    #endregion







    //just admin
    [Authorize]
    [HttpGet("[Action]")]
    public async Task<ActionResult<List<PaymentDTO>>> GetAllPayments()
    {


        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return BadRequest();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userId));
        if (!isadmin)
            return BadRequest();


        var payments = await _paymentService.GetAllPayments();

        return Ok(payments);


    }















}
