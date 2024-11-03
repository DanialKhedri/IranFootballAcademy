using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Drill.DrillType;

public class DrillTypeReadOnlyDTO
{
    public int Id { get; set; }



    public string UniqueName { get; set; }



    public string Description { get; set; }
}
