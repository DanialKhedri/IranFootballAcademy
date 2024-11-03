using Domain.Entities.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.Payment;

public interface IPaymentRepository
{

    public Task<List<Domain.Entities.Payment.Payment>> GetAllPayments();







}
