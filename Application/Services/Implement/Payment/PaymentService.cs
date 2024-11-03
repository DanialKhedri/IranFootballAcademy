using Application.DTOs.Payment;
using Application.Services.Interface.Payment;
using AutoMapper;
using Domain.IRepository.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implement.Payment;

public class PaymentService : IPaymentService
{

    private readonly IPaymentRepository _PaymentRepository;
    private readonly IMapper _mapper;
    public PaymentService(IPaymentRepository paymentRepository)
    {
        _PaymentRepository = paymentRepository;
    }

    public async Task<List<PaymentDTO>> GetAllPayments()
    {



        var payments = await _PaymentRepository.GetAllPayments();

        List<PaymentDTO> paymentDTOs = new List<PaymentDTO>();

        if (payments != null)
        {
            foreach (var item in payments)
            {
                PaymentDTO temp = new PaymentDTO()
                {
                    
                    Amount = item.Amount,
                    Date = item.Date,
                    OrderId = item.OrderId,
                    UserId = item.UserId,
                };

                paymentDTOs.Add(temp);


            }

        }


        return paymentDTOs;
    }

}
