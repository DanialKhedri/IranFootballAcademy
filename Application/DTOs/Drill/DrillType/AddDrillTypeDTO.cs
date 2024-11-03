using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Drill.DrillType;

public class AddDrillTypeDTO
{

    [Required]
    public string UniqueName { get; set; }


    [Required]
    public string Description { get; set; }

}
