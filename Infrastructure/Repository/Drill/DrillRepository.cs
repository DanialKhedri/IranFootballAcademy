#region Usings
using Application.DTOs.Drill.DrillAgeDTO;
using Domain.Entities.Drill;
using Domain.Entities.Drill.Ages;
using Domain.Entities.Drill.DrillType;
using Domain.IRepository.Drill;
using Infrastructure.Data;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Infrastructure.Repository.Drill;

public class DrillRepository : IDrillRepository
{
    #region Ctor

    private readonly DataContext _datacontext;

    public DrillRepository(DataContext datacontext)
    {
        _datacontext = datacontext;
    }

    #endregion


    #region GETs

    //Get All Drills
    public async Task<List<Domain.Entities.Drill.Drill>> GetAllDrills()
    {


        var Drills = await _datacontext.Drills.ToListAsync();

        foreach (var item in Drills)
        {



            item.DrillTypes = await _datacontext.SelectedDrillTypes.Where(d => d.DrillId == item.Id)
                                                                  .Select(d => d.DrillType).ToListAsync();




            item.DrillAges = await _datacontext.SelectedAges.Where(d => d.DrillId == item.Id)
                                                                  .Select(d => d.DrillAge)
                                                                  .ToListAsync();

        }

        return Drills;




    }


    //Get Free Drills
    public async Task<List<Domain.Entities.Drill.Drill>> GetFreeDrills()
    {
        var Drills = await _datacontext.Drills
                           .Where(d => d.IsFree == true && d.IsDelete == false)
                           .ToListAsync();

        return Drills;

    }


    //Get Drill By ID
    public async Task<Domain.Entities.Drill.Drill> GetDrillById(int DrillId)
    {
        try
        {
            var Drill = await _datacontext.Drills.FirstOrDefaultAsync(d => d.Id == DrillId);

            if (Drill == null)
                return null;



            Drill.DrillTypes = await _datacontext.SelectedDrillTypes.Where(d => d.DrillId == Drill.Id)
                                                                  .Select(d => d.DrillType).ToListAsync();




            Drill.DrillAges = await _datacontext.SelectedAges.Where(d => d.DrillId == Drill.Id)
                                                                  .Select(d => d.DrillAge)
                                                                  .ToListAsync();


            return Drill;
        }
        catch
        {
            return null;

        }





    }


    //Get Drill By Age
    public async Task<List<Domain.Entities.Drill.Drill>> GetDrillByAge(int AgeId)
    {

        try
        {

            var Drills = await _datacontext.SelectedAges.Where(s => s.DrillAgeId == AgeId)
                               .Select(s => s.Drill)
                               .ToListAsync();

            return Drills;
        }

        catch
        {

            return null;
        }


    }


    //Get Drill By Type
    public async Task<List<Domain.Entities.Drill.Drill>> GetDrillByType(int TypeId)
    {
        try
        {
            var Drills = await _datacontext.SelectedDrillTypes.Where(s => s.DrillTypeId == TypeId)
                               .Select(s => s.Drill)
                               .ToListAsync();

            return Drills;
        }
        catch
        {

            return null;
        }


    }

    #endregion



    //Remove Drill
    public async Task<bool> RemoveDrill(int DrillId)
    {

        var Drill = await _datacontext.Drills.FirstOrDefaultAsync(d => d.Id == DrillId && d.IsDelete == false);

        if (Drill != null)
        {
            try
            {
                //Delete Drill
                _datacontext.Drills.Remove(Drill);


                //Delete Selected Ages
                List<SelectedAge> selectedages = await _datacontext.SelectedAges.Where(d => d.DrillId == DrillId).ToListAsync();
                if (selectedages != null)
                    _datacontext.SelectedAges.RemoveRange(selectedages);


                //Delete Selected Types
                List<SelectedDrillType> selectedDrillTypes = await _datacontext.SelectedDrillTypes.Where(d => d.DrillId == DrillId).ToListAsync();
                if (selectedDrillTypes != null)
                    _datacontext.SelectedDrillTypes.RemoveRange(selectedDrillTypes);


                //Save Changes
                await _datacontext.SaveChangesAsync();


                return true;

            }
            catch
            {
                return false;

            }

        }
        else
            return false;

    }


    public async Task<bool> AddDrill(Domain.Entities.Drill.Drill drill, List<int> SelectedAges, List<int> SelectedTypes)

    {


        try
        {
            bool IsExist = await _datacontext.Drills.AnyAsync(d => d.Title == drill.Title);


            if (IsExist) { return false; }




            //Add Drill
            await _datacontext.Drills.AddAsync(drill);
            await _datacontext.SaveChangesAsync();


            //Get Drill By Title and Description and DateTime
            var drillId = _datacontext.Drills.FirstOrDefault(d => d.Title == drill.Title);


            if (drillId == null)
                return false;





            //SelectedAge

            if (SelectedAges != null && SelectedAges.Count != 0)
            {

                foreach (var item in SelectedAges)
                {

                    SelectedAge selectedAge = new SelectedAge();

                    selectedAge.DrillId = drillId.Id;
                    selectedAge.DrillAgeId = item;

                    await _datacontext.SelectedAges.AddAsync(selectedAge);


                }


            }

            //SelectedTypes
            if (SelectedTypes != null && SelectedTypes.Count != 0)
            {

                foreach (var item in SelectedTypes)
                {

                    SelectedDrillType selectedDrillType = new SelectedDrillType();


                    selectedDrillType.DrillId = drillId.Id;
                    selectedDrillType.DrillTypeId = item;


                    await _datacontext.SelectedDrillTypes.AddAsync(selectedDrillType);


                }


            }

            //Save Change

            await _datacontext.SaveChangesAsync();
            return true;
        }

        catch
        {

            return false;
        }

    }


    public async Task<bool> EditDrill(Domain.Entities.Drill.Drill drill,
         List<int> SelectedAges, List<int> SelectedTypes)
    {



        try
        {
            Domain.Entities.Drill.Drill? OriginDrill = await _datacontext.Drills.FirstOrDefaultAsync(d => d.Id == drill.Id);

            if (OriginDrill == null)
                return false;

            //Drill
            OriginDrill.Author = drill.Author;
            OriginDrill.Title = drill.Title;
            OriginDrill.Description = drill.Description;
            OriginDrill.Title2 = drill.Title2;
            OriginDrill.Description2 = drill.Description2;
            OriginDrill.Image = drill.Image;

            drill.DrillSetups = drill.DrillSetups;
            drill.DrillInstructions = drill.DrillInstructions;
            drill.DrillCoachingPoints = drill.DrillCoachingPoints;
            drill.DrillVariotions = drill.DrillVariotions;
            drill.Equipments = drill.Equipments;

            _datacontext.Drills.Update(OriginDrill);


            //Selected Ages
            if (SelectedAges != null)
            {

                var originselectedages = await _datacontext.SelectedAges
                    .Where(d => d.DrillId == OriginDrill.Id)
                    .ToListAsync();

                _datacontext.SelectedAges.RemoveRange(originselectedages);


                foreach (var item in SelectedAges)
                {
                    SelectedAge temp = new SelectedAge()
                    {
                        DrillId = OriginDrill.Id,
                        DrillAgeId = item,
                    };

                    _datacontext.SelectedAges.Add(temp);

                }

            }


            //Selected Types

            if (SelectedAges != null)
            {

                var originselectedTypes = await _datacontext.SelectedDrillTypes
                    .Where(d => d.DrillId == OriginDrill.Id)
                    .ToListAsync();

                _datacontext.SelectedDrillTypes.RemoveRange(originselectedTypes);


                foreach (var item in SelectedTypes)
                {
                    SelectedDrillType temp = new SelectedDrillType()
                    {
                        DrillId = OriginDrill.Id,
                        DrillTypeId = item,
                    };

                    _datacontext.SelectedDrillTypes.Add(temp);

                }

            }


            await _datacontext.SaveChangesAsync();
            return true;

        }
        catch
        {

            return false;
        }


    }


    #region DrillType

    //Get All Drill Types
    public async Task<List<DrillType>> GetAllDrillTypes()
    {

        try
        {

            return await _datacontext.DrillTypes.ToListAsync();

        }
        catch
        {

            return null;
        }

    }

    //Get Drill Type By Id

    public async Task<DrillType?> GetDrillTypeById(int DrillTypeId)
    {

        try
        {
            return await _datacontext.DrillTypes.FirstOrDefaultAsync(d => d.Id == DrillTypeId);

        }
        catch
        {

            return null;
        }

    }

    //Add Drill Type
    public async Task<bool> AddDrillType(DrillType drillType)
    {

        if (drillType == null)
            return false;


        try
        {
            await _datacontext.DrillTypes.AddAsync(drillType);
            await _datacontext.SaveChangesAsync();

            return true;


        }
        catch
        {

            return false;
        }

    }

    //Remove Drill Type
    public async Task<bool> RemoveDrillType(int DrillTypeId)
    {
        try
        {

            var drilltype = await _datacontext.DrillTypes.FirstOrDefaultAsync(d => d.Id == DrillTypeId);

            if (drilltype == null)
                return false;

            _datacontext.DrillTypes.Remove(drilltype);
            await _datacontext.SaveChangesAsync();

            return true;
        }
        catch
        {

            return false;
        }
    }

    #endregion


    #region Drill Age


    //GetAll DrillAges
    public async Task<List<DrillAge>> GetAllDrillAges()
    {
        try
        {
            return await _datacontext.DrillAges.ToListAsync();

        }
        catch
        {
            return null;

        }
    }


    //Get Drill Age By Id
    public async Task<DrillAge?> GetDrillAgeById(int DrillAgeId)
    {
        try
        {
            return await _datacontext.DrillAges.FirstOrDefaultAsync();

        }
        catch
        {

            return null;
        }
    }


    //Add Drill Age 
    public async Task<bool> AddDrillAge(DrillAge drillAge)
    {
        if (drillAge == null)
            return false;

        try
        {

            await _datacontext.DrillAges.AddAsync(drillAge);
            await _datacontext.SaveChangesAsync();

            return true;
        }
        catch
        {

            return false;
        }

    }


    //Remove Drill Age
    public async Task<bool> RemoveDrillAge(int DrillAgeId)
    {

        try
        {
            var DrillAge = await _datacontext.DrillAges.FirstOrDefaultAsync(d => d.Id == DrillAgeId);

            if (DrillAge == null)
                return false;

            _datacontext.DrillAges.Remove(DrillAge);
            await _datacontext.SaveChangesAsync();

        }
        catch
        {

            return false;

        }

        return true;

    }

    #endregion


}
