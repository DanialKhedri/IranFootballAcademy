using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Drill.DrillInstructions;

public class DrillInstruction
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int DrillId { get; set; }

    [Required]
    public string Instruction { get; set; }

}
