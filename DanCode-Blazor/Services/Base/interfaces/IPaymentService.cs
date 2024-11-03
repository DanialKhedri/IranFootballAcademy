namespace DanCode_Blazor.Services.Base.interfaces;

public interface IPaymentService
{


    public Task<PaymentRequestResponse> PaymentRequestAsync(PaymentRequestInputModel model);
    public Task<PaymentVerificationResponse> PaymentVerificationAsync(PaymentVerificationInputModel model);

    public Task<Response<ICollection<PaymentDTO>>> GetAllPayments();




}
