﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User.UserLogInDTO;

public class UserResultLogInDTO
{

    
    public int? Id { get; set; }


    public string? FullName { get; set; }


    public string? PhoneNumber { get; set; }


    public string? JWTToken { get; set; }


    public string? RefreshToken { get; set; }
}
