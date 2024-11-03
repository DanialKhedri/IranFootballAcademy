#region Usings
using Application.DTOs.Drill;
using Application.DTOs.Drill.DrillAgeDTO;
using Application.DTOs.Drill.DrillType;
using Application.Services.Interface.Drill;
using AutoMapper;
using Domain.Entities.Drill;
using Domain.Entities.Drill.Ages;

using Domain.Entities.Drill.DrillType;
using Domain.Entities.Drill.DrillVariotion;
using Domain.IRepository.Drill;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Application.Services.Implement.Drilll;

public class DrillService : IDrillService
{

    #region Ctor

    private readonly IDrillRepository _drillrepository;
    private readonly IMapper _mapper;
    public DrillService(IDrillRepository drillrepository, IMapper mapper)
    {
        _drillrepository = drillrepository;
        _mapper = mapper;
    }

    #endregion


    #region Gets

    //Get All Drills
    public async Task<List<DrillReadonlyDTO>> GetAllDrills()
    {

        var Drills = await _drillrepository.GetAllDrills();

        List<DrillReadonlyDTO> drillReadonlyDTOs = new List<DrillReadonlyDTO>();

        if (Drills != null)
        {
            foreach (var item in Drills)
            {


                DrillReadonlyDTO temp = new DrillReadonlyDTO()
                {
                    Id = item.Id,

                    Author = item.Author,
                    CreateDate = item.CreateDate,

                    Image = item.Image,

                    Title = item.Title,
                    Description = item.Description,
                    Title2 = item.Title2,
                    Description2 = item.Description2,

                    DrillSetups = item.DrillSetups,
                    DrillInstructions = item.DrillInstructions,
                    DrillVariotions = item.DrillVariotions,
                    DrillCoachingPoints = item.DrillCoachingPoints,
                    Equipments = item.Equipments,

                    DrillAges = item.DrillAges,
                    DrillTypes = item.DrillTypes,

                };

                drillReadonlyDTOs.Add(temp);

            }
        }


        return drillReadonlyDTOs;


    }


    //Get Free Drills
    public async Task<List<DrillReadonlyDTO>> GetFreeDrills()
    {


        var Drills = await _drillrepository.GetAllDrills();

        List<DrillReadonlyDTO> drillReadonlyDTOs = new List<DrillReadonlyDTO>();

        if (Drills != null)
        {
            foreach (var item in Drills)
            {

                var drill = _mapper.Map<DrillReadonlyDTO>(item);
                drillReadonlyDTOs.Add(drill);

            }
        }


        return drillReadonlyDTOs;



    }


    //Get  Drill By Id
    public async Task<DrillReadonlyDTO> GetDrillById(int DrillId)
    {
        var drill = await _drillrepository.GetDrillById(DrillId);

        if (drill != null)
        {
            DrillReadonlyDTO temp = new DrillReadonlyDTO()
            {
                Id = drill.Id,

                Author = drill.Author,
                CreateDate = drill.CreateDate,

                Image = drill.Image,

                Title = drill.Title,
                Description = drill.Description,
                Title2 = drill.Title2,
                Description2 = drill.Description2,

                DrillSetups = drill.DrillSetups,
                DrillInstructions = drill.DrillInstructions,
                DrillVariotions = drill.DrillVariotions,
                DrillCoachingPoints = drill.DrillCoachingPoints,
                Equipments = drill.Equipments,

                DrillAges = drill.DrillAges,
                DrillTypes = drill.DrillTypes,

            };

            return temp;

        }
        return null;

    }


    //Get Drills By Age
    public async Task<List<DrillReadonlyDTO>> GetDrillsByAge(int AgeId)
    {

        var Drills = await _drillrepository.GetDrillByAge(AgeId);

        List<DrillReadonlyDTO> drillReadonlyDTOs = new List<DrillReadonlyDTO>();

        if (Drills != null)
        {

            foreach (var item in Drills)
            {

                DrillReadonlyDTO temp = new DrillReadonlyDTO()
                {
                    Id = item.Id,

                    Author = item.Author,
                    CreateDate = item.CreateDate,

                    Image = item.Image,

                    Title = item.Title,
                    Description = item.Description,
                    Title2 = item.Title2,
                    Description2 = item.Description2,

                    DrillSetups = item.DrillSetups,
                    DrillInstructions = item.DrillInstructions,
                    DrillVariotions = item.DrillVariotions,
                    DrillCoachingPoints = item.DrillCoachingPoints,
                    Equipments = item.Equipments,

                    DrillAges = item.DrillAges,
                    DrillTypes = item.DrillTypes,

                };

                drillReadonlyDTOs.Add(temp);


            }

        }

        return drillReadonlyDTOs;

    }


    //Get Drills By Type
    public async Task<List<DrillReadonlyDTO>> GetDrillsByType(int TypeId)
    {

        var Drills = await _drillrepository.GetDrillByType(TypeId);

        List<DrillReadonlyDTO> drillReadonlyDTOs = new List<DrillReadonlyDTO>();

        if (Drills != null)
        {

            foreach (var item in Drills)
            {

                DrillReadonlyDTO temp = new DrillReadonlyDTO()
                {
                    Id = item.Id,

                    Author = item.Author,
                    CreateDate = item.CreateDate,

                    Image = item.Image,

                    Title = item.Title,
                    Description = item.Description,
                    Title2 = item.Title2,
                    Description2 = item.Description2,

                    DrillSetups = item.DrillSetups,
                    DrillInstructions = item.DrillInstructions,
                    DrillVariotions = item.DrillVariotions,
                    DrillCoachingPoints = item.DrillCoachingPoints,
                    Equipments = item.Equipments,

                    DrillAges = item.DrillAges,
                    DrillTypes = item.DrillTypes,
                };

                drillReadonlyDTOs.Add(temp);


            }

        }

        return drillReadonlyDTOs;

    }


    #endregion


    #region Drill

    //Add Drill
    public async Task<bool> AddDrill(AddDrillDTO addDrilldto)
    {

        try
        {

            //Drill
            Drill drill = new Drill();

            drill.Author = addDrilldto.Author;
            drill.Description = addDrilldto.Description;
            drill.Title = addDrilldto.Title;

            drill.Description2 = addDrilldto.Description2;
            drill.Title2 = addDrilldto.Title2;
            drill.Image = addDrilldto.Image;

            drill.DrillSetups = addDrilldto.DrillSetups;
            drill.DrillInstructions = addDrilldto.DrillInstructions;
            drill.DrillVariotions = addDrilldto.DrillVariotions;
            drill.DrillCoachingPoints = addDrilldto.DrillCoachingPoints;
            drill.Equipments = addDrilldto.Equipments;



            return await _drillrepository.AddDrill(drill, addDrilldto.SelectedAges, addDrilldto.DrillTypes);




        }
        catch
        {

            return false;

        }


    }


    //Edit Drill
    public async Task<bool> EditDrill(EditDrillDTO editDrillDTO)
    {

        //Drill
        Drill drill = new Drill();

        drill.Id = editDrillDTO.Id;
        drill.Author = editDrillDTO.Author;
        drill.Description = editDrillDTO.Description;
        drill.Title = editDrillDTO.Title;

        drill.Description2 = editDrillDTO.Description2;
        drill.Title2 = editDrillDTO.Title2;
        drill.Image = editDrillDTO.Image;

        drill.DrillSetups = editDrillDTO.DrillSetups;
        drill.DrillInstructions = editDrillDTO.DrillInstructions;
        drill.DrillCoachingPoints = editDrillDTO.DrillCoachingPoints;
        drill.DrillVariotions = editDrillDTO.DrillVariotions;
        drill.Equipments = editDrillDTO.Equipments;

        return await _drillrepository.EditDrill(drill, editDrillDTO.SelectedAges, editDrillDTO.SelectedTypes);

    }


    //Remove Drill
    public async Task<bool> RemoveDrill(int DrillId)
    {

        return await _drillrepository.RemoveDrill(DrillId);
    }

    #endregion


    #region DrillType


    //Get All Drill Types
    public async Task<List<DrillTypeReadOnlyDTO>> GetAllDrillTypes()
    {

        var DrillTypes = await _drillrepository.GetAllDrillTypes();

        List<DrillTypeReadOnlyDTO> drillReadonlyDTOs = new List<DrillTypeReadOnlyDTO>();

        if (DrillTypes == null)
            return drillReadonlyDTOs;

        foreach (var drillType in DrillTypes)
        {
            var dto = _mapper.Map<DrillTypeReadOnlyDTO>(drillType);
            drillReadonlyDTOs.Add(dto);
        }

        return drillReadonlyDTOs;

    }

    public async Task<DrillTypeReadOnlyDTO?> GetDrillTypeById(int DrillTypeId)
    {

        var drilltype = await _drillrepository.GetDrillTypeById(DrillTypeId);
        if (drilltype != null)
        {


            var dto = _mapper.Map<DrillTypeReadOnlyDTO>(drilltype);


            return dto;
        }
        else
            return null;


    }


    //Add Drill Type
    public async Task<bool> AddDrillType(AddDrillTypeDTO drillTypeDTO)
    {
        if (drillTypeDTO == null)
            return false;


        var drilltype = _mapper.Map<DrillType>(drillTypeDTO);

        return await _drillrepository.AddDrillType(drilltype);


    }


    //Remove Drill Type
    public async Task<bool> RemoveDrillType(int DrillTypeId)
    {
        return await _drillrepository.RemoveDrillType(DrillTypeId);
    }

    #endregion


    #region DrillAge




    //Get All Drill Ages
    public async Task<List<DrillAgeReadonlyDTO>> GetAllDrillAges()
    {

        var DrillAges = await _drillrepository.GetAllDrillAges();

        List<DrillAgeReadonlyDTO> drillReadonlyDTOs = new List<DrillAgeReadonlyDTO>();

        if (DrillAges == null)
            return drillReadonlyDTOs;

        foreach (var drillage in DrillAges)
        {
            var dto = _mapper.Map<DrillAgeReadonlyDTO>(drillage);
            drillReadonlyDTOs.Add(dto);
        }

        return drillReadonlyDTOs;

    }


    public async Task<DrillAgeReadonlyDTO?> GetDrillAgeById(int DrillAgeId)
    {
        var DrillAge = await _drillrepository.GetDrillAgeById(DrillAgeId);

        if (DrillAge != null)
        {

            var dto = _mapper.Map<DrillAgeReadonlyDTO>(DrillAge);

            return dto;
        }
        return null;
    }

    //Add DrillAge
    public async Task<bool> AddDrilAge(AddDrillAgeReadDTO drillAgeDTO)
    {
        if (drillAgeDTO == null)
            return false;


        var DrillAge = _mapper.Map<DrillAge>(drillAgeDTO);
        return await _drillrepository.AddDrillAge(DrillAge);
    }


    //Remove DrillAge
    public async Task<bool> RemoveDrillAge(int DrillAgeId)
    {
        return await _drillrepository.RemoveDrillAge(DrillAgeId);
    }


    #endregion

}
