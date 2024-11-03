#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage = "نام الزامی است")]
    public string FullName { get; set; }




    [Required(ErrorMessage = "شماره تلفن الزامی است")]
    [StringLength(11, ErrorMessage = "شماره تلفن باید دقیقا 11 رقم باشد", MinimumLength = 11)]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "شماره تلفن باید فقط شامل اعداد باشد")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "گذرواژه الزامی است")]
    [StringLength(40, MinimumLength = 8, ErrorMessage = "گذرواژه باید حداقل 8 و حداکثر 40 کاراکتر باشد")]
    public string Password { get; set; }


    [Required]
    public bool IsAdmin { get; set; } = false;


    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }

    [NotMapped]
    public string? JWTToken { get; set; }


}
