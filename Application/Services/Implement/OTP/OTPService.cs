using Application.DTOs.OTP;
using Application.Services.Interface.OTP;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implement.OTP;

public class OTPService : IOTPService
{



    // آدرس پایه وب‌سرویس
    private const string endpoint = "https://rest.payamak-panel.com/api/SendSMS/";

    // عملیات‌های موجود در وب‌سرویس
    private const string sendOp = "SendSMS";
    private const string getDeliveryOp = "GetDeliveries2";
    private const string getMessagesOp = "GetMessages";
    private const string getCreditOp = "GetCredit";
    private const string getBasePriceOp = "GetBasePrice";
    private const string getUserNumbersOp = "GetUserNumbers";
    private const string sendByBaseNumberOp = "BaseServiceNumber";

    // مقادیر نام کاربری و رمز عبور که باید از محیط تنظیم شوند
    private string UserName = "9336314704";  // مقدار نام کاربری
    private string Password = "LS!40";  // مقدار رمز عبور

    // متدی برای ایجاد درخواست به وب‌سرویس و ارسال داده‌ها
    private async Task<RestResponseModel> makeRequestAsync(Dictionary<string, string> values, string op)
    {
        // تبدیل داده‌ها به فرمت مناسب برای ارسال
        var content = new FormUrlEncodedContent(values);

        // استفاده از HttpClient برای ارسال درخواست
        using (var httpClient = new HttpClient())
        {
            // ارسال درخواست به وب‌سرویس با متد POST
            var response = await httpClient.PostAsync(endpoint + op, content);

            // دریافت پاسخ به صورت رشته
            var responseString = await response.Content.ReadAsStringAsync();

            // تبدیل پاسخ به یک آبجکت RestResponse و بازگرداندن آن
            return JsonConvert.DeserializeObject<RestResponseModel>(responseString);
        }
    }

    // متدی برای ارسال پیامک
    public async Task<RestResponseModel> SendAsync(string to, string from, string message, bool isFlash)
    {
        // ساخت دیکشنری از پارامترها برای ارسال
        var values = new Dictionary<string, string>
        {
            { "username", UserName },
            { "password", Password },
            { "to", to },
            { "from", from },
            { "text", message },
            { "isFlash", isFlash.ToString() }
        };

        // فراخوانی متد ارسال پیامک
        return await makeRequestAsync(values, sendOp);
    }

    // متدی برای ارسال پیامک از طریق شماره‌های پایه
    public async Task<RestResponseModel> SendByBaseNumberAsync(string text, string to, int bodyId)
    {
        // ساخت دیکشنری از پارامترها برای ارسال پیامک از طریق شماره‌های پایه
        var values = new Dictionary<string, string>
        {
            { "username", UserName },
            { "password", Password },
            { "text", text },
            { "to", to },
            { "bodyId", bodyId.ToString() }
        };

        // فراخوانی متد برای ارسال پیامک
        return await makeRequestAsync(values, sendByBaseNumberOp);
    }

    // متدی برای دریافت وضعیت تحویل پیامک
    public async Task<RestResponseModel> GetDeliveryAsync(long recid)
    {
        // ساخت دیکشنری از پارامترهای لازم برای دریافت وضعیت
        var values = new Dictionary<string, string>
        {
            { "UserName", UserName },
            { "PassWord", Password },
            { "recID", recid.ToString() }
        };

        // فراخوانی متد برای دریافت وضعیت تحویل پیامک
        return await makeRequestAsync(values, getDeliveryOp);
    }

    // متدی برای دریافت پیام‌های دریافتی
    public async Task<RestResponseModel> GetMessagesAsync(int location, string from, string index, int count)
    {
        // ساخت دیکشنری از پارامترها برای دریافت پیام‌ها
        var values = new Dictionary<string, string>
        {
            { "UserName", UserName },
            { "PassWord", Password },
            { "Location", location.ToString() },
            { "From", from },
            { "Index", index },
            { "Count", count.ToString() }
        };

        // فراخوانی متد برای دریافت پیام‌ها
        return await makeRequestAsync(values, getMessagesOp);
    }

    // متدی برای دریافت اعتبار حساب کاربری
    public async Task<RestResponseModel> GetCreditAsync()
    {
        // ساخت دیکشنری از پارامترها برای دریافت اعتبار
        var values = new Dictionary<string, string>
        {
            { "UserName", UserName },
            { "PassWord", Password }
        };

        // فراخوانی متد برای دریافت اعتبار
        return await makeRequestAsync(values, getCreditOp);
    }

    // متدی برای دریافت قیمت پایه ارسال پیامک
    public async Task<RestResponseModel> GetBasePriceAsync()
    {
        // ساخت دیکشنری از پارامترهای لازم برای دریافت قیمت پایه
        var values = new Dictionary<string, string>
        {
            { "UserName", UserName },
            { "PassWord", Password }
        };

        // فراخوانی متد برای دریافت قیمت پایه
        return await makeRequestAsync(values, getBasePriceOp);
    }

    // متدی برای دریافت لیست شماره‌های کاربر
    public async Task<RestResponseModel> GetUserNumbersAsync()
    {
        // ساخت دیکشنری از پارامترها برای دریافت شماره‌های کاربر
        var values = new Dictionary<string, string>
        {
            { "UserName", UserName },
            { "PassWord", Password }
        };

        // فراخوانی متد برای دریافت شماره‌های کاربر
        return await makeRequestAsync(values, getUserNumbersOp);
    }



}
