#region usings
using Application.DTOs.Drill;
using Application.DTOs.Drill.DrillAgeDTO;
using Application.DTOs.Drill.DrillType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Application.Services.Interface.Drill;

public interface IDrillService
{

    public Task<bool> AddDrill(AddDrillDTO addDrillDTO);
    public Task<bool> EditDrill(EditDrillDTO editDrillDTO);

    public Task<List<DrillReadonlyDTO>> GetAllDrills();

    public Task<List<DrillReadonlyDTO>> GetFreeDrills();

    public Task<DrillReadonlyDTO> GetDrillById(int DrillId);

    public Task<List<DrillReadonlyDTO>> GetDrillsByAge(int AgeId);



    public Task<List<DrillReadonlyDTO>> GetDrillsByType(int TypeId);

    public Task<bool> RemoveDrill(int DrillId);


    public Task<bool> AddDrillType(AddDrillTypeDTO drillTypeDTO);

    public Task<bool> RemoveDrillType(int DrillTypeId);

    public Task<bool> AddDrilAge(AddDrillAgeReadDTO drillAgeDTO);

    public Task<bool> RemoveDrillAge(int DrillAgeId);


    public Task<List<DrillAgeReadonlyDTO>> GetAllDrillAges();
    public Task<DrillAgeReadonlyDTO?> GetDrillAgeById(int DrillAgeId);

    public Task<List<DrillTypeReadOnlyDTO>> GetAllDrillTypes();
    public Task<DrillTypeReadOnlyDTO?> GetDrillTypeById(int DrillTypeId);

}
