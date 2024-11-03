#region usings
using Domain.Entities.Drill.Ages;
using Domain.Entities.Drill.DrillType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Domain.IRepository.Drill
{
    public interface IDrillRepository
    {


        //Get All Drills
        public Task<List<Domain.Entities.Drill.Drill>> GetAllDrills();


        //Get Free Drills
        public Task<List<Domain.Entities.Drill.Drill>> GetFreeDrills();


        //Get Drill By Id
        public Task<Domain.Entities.Drill.Drill> GetDrillById(int DrillId);


        //Get Drills By Age
        public Task<List<Domain.Entities.Drill.Drill>> GetDrillByAge(int AgeId);


        //Get Drill By Type
        public Task<List<Domain.Entities.Drill.Drill>> GetDrillByType(int TypeId);



        //Add Drill
        public Task<bool> AddDrill(Domain.Entities.Drill.Drill drill, List<int> SelectedAges, List<int> SelectedTypes);


        //Edit
        public Task<bool> EditDrill(Domain.Entities.Drill.Drill drill,
          List<int> SelectedAges, List<int> SelectedTypes);

        //Remove Drill
        public Task<bool> RemoveDrill(int DrillId);



        //Get All DrillTypes
        public Task<List<DrillType>> GetAllDrillTypes();

        //Get DrillType
        public Task<DrillType?> GetDrillTypeById(int DrillTypeId);


        //Add DrillType
        public Task<bool> AddDrillType(DrillType drillType);

        //Remove DrillType
        public Task<bool> RemoveDrillType(int DrillTypeId);



        //Get All Drill Ages
        public Task<List<DrillAge>> GetAllDrillAges();

        //Get Drill Age By Id
        public Task<DrillAge?> GetDrillAgeById(int DrillAgeId);

        //Add Drill Age
        public Task<bool> AddDrillAge(DrillAge drillAge);



        //Remove Drill Age
        public Task<bool> RemoveDrillAge(int DrillAgeId);




    }
}
