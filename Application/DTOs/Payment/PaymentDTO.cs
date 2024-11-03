using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Payment;

public class PaymentDTO
{



    public DateTime Date { get; set; } 

    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int Amount { get; set; }





}
