namespace DanCode_Blazor.Services.Base.interfaces
{
    public interface IDrillService
    {


        #region Drill
        public Task<Response<List<DrillReadonlyDTO>>> GetAllDrills();

        public Task<Response<DrillReadonlyDTO>> GetDrillById(int DrillId);

        public Task<Response<bool>> AddDrill(AddDrillDTO addDrillDTO);

        public Task<Response<bool>> EditDrill(EditDrillDTO dto);

        public Task<Response<bool>> RemoveDrill(int DrillId);

        #endregion



        #region DrillAges

        public Task<Response<List<DrillAgeReadonlyDTO>>> GetAllDrillAges();

        public Task<Response<bool>> AddDrillAge(AddDrillAgeReadDTO addDrillAgedto);

        public Task<Response<bool>> RemoveDrillAge(int DrillAgeId);


        #endregion



        #region DrillTypes

        //Get All DrillTypes
        public Task<Response<List<DrillTypeReadOnlyDTO>>> GetAllDrillTypes();

        //Add Drill Type
        public Task<Response<bool>> AddDrillType(AddDrillTypeDTO addDrillTypeDTO);


        //Remove Drill Type
        public Task<Response<bool>> RemoveDrillType(int DrillTypeId);

        #endregion



    }
}
