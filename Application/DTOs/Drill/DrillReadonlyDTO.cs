﻿#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Application.DTOs.Drill;

public class DrillReadonlyDTO
{

    public int Id { get; set; }


    public string Author { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Today;


    public string Image { get; set; }


    public string Title { get; set; }
    public string Description { get; set; }
    public string Title2 { get; set; }
    public string Description2 { get; set; }

    public bool IsFree { get; set; } = false;


    public bool IsDelete { get; set; } = false;

    public string DrillSetups { get; set; }
    public string DrillInstructions { get; set; }
    public string DrillVariotions { get; set; }
    public string DrillCoachingPoints { get; set; }
    public string Equipments { get; set; }




    
    public List<Domain.Entities.Drill.Ages.DrillAge> DrillAges { get; set; }

    public List<Domain.Entities.Drill.DrillType.DrillType> DrillTypes { get; set; }









}