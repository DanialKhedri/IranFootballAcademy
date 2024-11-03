using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OTP;

public class SendAsyncParameters
{

    public string to { get; set; }
    public string from { get; set; }
    public string message { get; set; }
    public bool isFlash { get; set; }


}

