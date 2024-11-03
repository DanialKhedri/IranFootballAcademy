using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OTP
{
    public class RestResponseModel
    {


        // مقدار اصلی پاسخ (متن پیامک یا اعتبار)
        public string Value { get; set; }

        // وضعیت بازگشتی: عددی که وضعیت درخواست را مشخص می‌کند
        public int RetStatus { get; set; }

        // توضیحات وضعیت: متنی که وضعیت درخواست را به‌صورت خوانا توضیح می‌دهد
        public string StrRetStatus { get; set; }

    }
}
