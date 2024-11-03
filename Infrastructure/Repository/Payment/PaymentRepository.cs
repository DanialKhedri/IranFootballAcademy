using Application.DTOs.Payment;
using Application.Services.Interface.Payment;
using Domain.IRepository.Payment;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Payment;

public class PaymentRepository : IPaymentRepository
{
    private readonly DataContext _datacontext;
    public PaymentRepository(DataContext datacontext)
    {
        _datacontext = datacontext;
    }
    public async Task<List<Domain.Entities.Payment.Payment>> GetAllPayments()
    {

        try
        {

            var payments = await _datacontext.Payments.ToListAsync();

            return payments;
        }
        catch
        {

            return null;
        }





    }

}
