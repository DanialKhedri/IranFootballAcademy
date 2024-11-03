using Application.DTOs.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface.Payment;

public interface IPaymentService
{


    public Task<List<PaymentDTO>> GetAllPayments();








}
