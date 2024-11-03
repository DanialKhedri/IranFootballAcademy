using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities.Generators;

public static class OTPGenerator
{

    //Generate Random OTP
    public static string GenerateRandomOTP()
    {
        Random random = new Random();
        int otpCode = random.Next(100000, 999999);  // تولید یک عدد رندوم بین 100000 و 999999
        return otpCode.ToString();  // تبدیل عدد به رشته و برگرداندن آن
    }










}
