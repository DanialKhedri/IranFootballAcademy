using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Course.Video;

public class ReadOnlyVideoDTO
{


    public string VideoUrl { get; set; }

    public string Title { get; set; }

    public int Order { get; set; }
}
