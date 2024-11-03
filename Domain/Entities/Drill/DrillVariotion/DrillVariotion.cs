using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Drill.DrillVariotion;

public class DrillVariotion
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int DrillId { get; set; }

    [Required]
    public string Variotion { get; set; }

}
