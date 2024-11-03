#region usings
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Domain.Entities.Drill.Equipment;

public class DrillEquipment
{
    [Required]
    public  int Id { get; set; }

    [Required]
    public int DrillId { get; set; }

    [Required]
    public string Equipmnet { get; set; }


}
