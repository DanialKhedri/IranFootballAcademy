#region
using Domain.Entities.Drill.DrillType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Drill.DrillType;
#endregion

namespace Domain.Entities.Drill.DrillType;

public class SelectedDrillType
{

    [Required]
    public int Id { get; set; }

    [Required]
    public int DrillId { get; set; }

    [Required]
    public int DrillTypeId { get; set; }





    //Navigation Properties
    public Drill Drill { get; set; }
    public DrillType DrillType { get; set; }

}
