#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Domain.Entities.Product;

public class BuyedProduct
{

    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public DateTime DateBuyed { get; set; } = DateTime.Now;


    //Navigation Properties

    public User User { get; set; }

    public Product Product { get; set; }


}
