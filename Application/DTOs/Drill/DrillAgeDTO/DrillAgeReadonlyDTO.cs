using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Drill.DrillAgeDTO
{
    public class DrillAgeReadonlyDTO
    {


        public int Id { get; set; }


        public int Age { get; set; }

 
        public string Description { get; set; }

    }
}
