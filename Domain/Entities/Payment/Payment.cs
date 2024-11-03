#region usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Domain.Entities.Payment;

public class Payment
{
    public int Id { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int Amount { get; set; }

}
