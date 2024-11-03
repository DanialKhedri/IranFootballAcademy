using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Payment;

public class PaymentRequestInputModel
{

    public long Amount { get; set; }

    public string OrderId { get; set; }


}
