#region usings
using Blazored.LocalStorage;
using DanCode_Blazor.Services.Base;
using DanCode_Blazor.Services.Base.interfaces;
using Newtonsoft.Json;
#endregion

namespace DanCode_Blazor.Services.PaymentService;

public class PaymentService : BaseHttpService, IPaymentService
{
    #region Ctor

    private readonly IClient client;
    public PaymentService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {
        this.client = client;
    }

    #endregion

    // متد برای درخواست پرداخت
    public async Task<PaymentRequestResponse> PaymentRequestAsync(PaymentRequestInputModel model)
    {
        // ارسال درخواست به API
        var response = await client.PaymentRequestAsync(model);

        // بررسی اینکه آیا درخواست موفق بوده است یا خیر
        if (response.Success == 1)
        {
            return response;
        }
        else
        {
            // مدیریت خطا
            return new PaymentRequestResponse() { Success = -1, Message = "خطا در درخواست پرداخت" };
        }
    }


    // متد برای تایید پرداخت
    public async Task<PaymentVerificationResponse> PaymentVerificationAsync(PaymentVerificationInputModel model)
    {
        // ارسال درخواست تاییدیه به API
        var response = await client.PaymentVerificationAsync(model);

        // بررسی موفقیت آمیز بودن درخواست
        if (response.Success == 1)
        {
            return response;
        }

        else
        {
            // مدیریت خطا
            return new PaymentVerificationResponse() { Success = -1, Message = "خطا در تایید پرداخت" };
        }

    }


    public async Task<Response<ICollection<PaymentDTO>>> GetAllPayments()
    {

        Response<ICollection<PaymentDTO>> response;

        try
        {

            await GetBearerToken();

            var data = await client.GetAllPaymentsAsync();


            response = new Response<ICollection<PaymentDTO>>
            {
                Data = data,
                Success = true,
            };



        }

        catch (ApiException exception)
        {

            response = ConvertApiExceptions<ICollection<PaymentDTO>>(exception);

        }

        return response;
    }



}








