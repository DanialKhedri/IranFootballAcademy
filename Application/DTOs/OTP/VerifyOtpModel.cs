using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OTP;

public class VerifyOtpModel
{
    public string PhoneNumber { get; set; }
    public string OtpCode { get; set; }
}
