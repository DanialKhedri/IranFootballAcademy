#region usings
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace Domain.Entities.Drill.Ages;

public class SelectedAge
{



    [Required]
    public int Id { get; set; }
    [Required]
    public int DrillId { get; set; }
    [Required]
    public  int  DrillAgeId { get; set; }


    
    public Drill Drill { get; set; }
    public DrillAge DrillAge { get; set; }

  
}
