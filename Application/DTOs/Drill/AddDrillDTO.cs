using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Drill;

public class AddDrillDTO
{

    [Required]
    public string Author { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Title2 { get; set; }
    [Required]
    public string Description2 { get; set; }


    public string? Image { get; set; }
    //public IFormFile formFileImage { get; set; }

    [Required]
    public string DrillSetups { get; set; }
    [Required]
    public string DrillInstructions { get; set; }
    [Required]
    public string DrillVariotions { get; set; }
    [Required]
    public string DrillCoachingPoints { get; set; }
    [Required]
    public string Equipments { get; set; }




    public List<int> SelectedAges { get; set; }
    public List<int> DrillTypes { get; set; }


}
