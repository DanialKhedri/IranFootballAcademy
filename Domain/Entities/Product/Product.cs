﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product;

public class Product
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int Price { get; set; }


    public string? ImageUrl { get; set; }


    [Required]
    public string FileUrl { get; set; }



    //Nvigation Properties


}
