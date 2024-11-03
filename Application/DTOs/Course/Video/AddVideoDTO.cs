using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Course.Video;

public class AddVideoDTO
{

    public string Title { get; set; }

    public string VideoUrl { get; set; }

    public int Order { get; set; }



}
