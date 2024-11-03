using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OTP
{
    public class OtpModel
    {
        public string PhoneNumber { get; set; }
        public string OtpCode { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}
