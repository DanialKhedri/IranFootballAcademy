using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Drill.DrillCoachingPoint;

public class DrillCoachingPoint
{
    public int Id { get; set; }

    [Required]
    public int DrillId { get; set; }

    [Required]
    public string CoachingPoint { get; set; }

}

