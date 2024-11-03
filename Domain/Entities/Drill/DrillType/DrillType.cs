#region
using Domain.Entities.Drill.DrillType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Domain.Entities.Drill.DrillType;

public class DrillType
{

    [Required]
    public int Id { get; set; }


    [Required]
    public string UniqueName { get; set; }


    [Required]
    public string Description { get; set; }


    //Navigation Properties
    public List<SelectedDrillType> SelectedDrillTypes { get; set; }

}
