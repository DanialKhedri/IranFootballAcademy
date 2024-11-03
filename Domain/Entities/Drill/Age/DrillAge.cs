#region usings
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Domain.Entities.Drill.Ages;

public class DrillAge
{

    [Required]
    public int Id { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public string Description { get; set; }



    public List<Domain.Entities.Drill.Ages.SelectedAge> SelectedAges { get; set; }


}
