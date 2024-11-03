using Application.DTOs.OTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface.OTP;

public interface IOTPService
{
    public Task<RestResponseModel> SendAsync(string to, string from, string message, bool isFlash);


}

