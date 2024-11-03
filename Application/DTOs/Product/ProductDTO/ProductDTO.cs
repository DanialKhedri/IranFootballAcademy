using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Product.ProductDTO;

public class ProductDTO
{

    public int Id { get; set; }


    public string Name { get; set; }


    public string Description { get; set; }


    public int Price { get; set; }

    public string ImageUrl { get; set; }

    public string FileUrl { get; set; }

}
