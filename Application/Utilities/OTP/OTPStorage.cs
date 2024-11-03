using Application.DTOs.OTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities.OTP;

public static class OtpStorage
{
    public static List<OtpModel> Otps = new List<OtpModel>();

    public static void SaveOtp(OtpModel otp)
    {
        Otps.Add(otp);
    }

    public static OtpModel GetOtp(string phoneNumber)
    {
        return Otps.FirstOrDefault(x => x.PhoneNumber == phoneNumber && x.ExpiryTime > DateTime.Now);
    }

    public static void RemoveOtp(string phoneNumber)
    {
        Otps.RemoveAll(x => x.PhoneNumber == phoneNumber);
    }

}


