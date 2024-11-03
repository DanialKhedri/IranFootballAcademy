#region Usings
using Application.DTOs.Drill;
using Application.DTOs.Drill.DrillAgeDTO;
using Application.DTOs.Drill.DrillType;
using Application.Services.Interface.Drill;
using Application.Services.Interface.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
#endregion

namespace Sample_WebApi_For_Blazort.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DrillController : ControllerBase
{

    #region Ctor

    private readonly IDrillService _drillService;
    private readonly IUserService _userService;

    public DrillController(IDrillService drillService, IUserService userService)
    {
        _drillService = drillService;
        _userService = userService;
    }

    #endregion


    #region Drill

    //Get All Drills
    [HttpGet("[action]")]
    public async Task<ActionResult<List<DrillReadonlyDTO>>> GetAllDrills()
    {

        return await _drillService.GetAllDrills();


    }


    //Get Free Drills
    [HttpGet("[action]")]
    public async Task<ActionResult<List<DrillReadonlyDTO>>> GetFreeDrills()
    {
        var drills = await _drillService.GetFreeDrills();

        return Ok(drills);
    }



    //Get Drill By Id
    [HttpGet("[Action]")]
    public async Task<ActionResult<DrillReadonlyDTO>> GetDrillById(int DrillId)
    {

        var Drill = await _drillService.GetDrillById(DrillId);

        return Drill;



    }



    //Get Drills By Age
    [HttpGet("[Action]/{AgeId}")]
    public async Task<ActionResult<List<DrillReadonlyDTO>>> GetDrillByAge(int AgeId)
    {
        var Drills = await _drillService.GetDrillsByAge(AgeId);

        return Ok(Drills);
    }



    //Get Drills by Type
    [HttpGet("[Action]/{TypeId}")]
    public async Task<ActionResult<List<DrillReadonlyDTO>>> GetDrillByType(int TypeId)
    {
        var Drills = await _drillService.GetDrillsByType(TypeId);

        return Ok(Drills);
    }



    //Add Drill
    //Just Admin
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> AddDrill(AddDrillDTO addDrillDTO)
    {

        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();

        if (!ModelState.IsValid)
            return BadRequest();


        if (addDrillDTO == null)
            return BadRequest();


        bool Result = await _drillService.AddDrill(addDrillDTO);

        return Ok(Result);

    }



    //Edit Drill
    //Just Admin
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> EditDrill(EditDrillDTO dTO)
    {

        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();


        var result = await _drillService.EditDrill(dTO);

        return Ok(result);
    }


    //Remove Drill
    //Just Admin
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> RemoveDrill(int DrillId)
    {
        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();

        var Result = await _drillService.RemoveDrill(DrillId);

        return Ok(Result);
    }

    #endregion


    #region Drill types


    //Get All Drill Types
    [HttpGet("[Action]")]
    public async Task<ActionResult<List<DrillTypeReadOnlyDTO>>> GetAllDrillTypes()
    {

        var DrillTypes = await _drillService.GetAllDrillTypes();
        return Ok(DrillTypes);

    }

    //Get Drill type by Id 
    [HttpGet("[Action]")]
    public async Task<ActionResult<DrillTypeReadOnlyDTO>> GetDrillTypeById(int DrilltypeId)
    {

        var dto = await _drillService.GetDrillTypeById(DrilltypeId);

        if (dto == null)
            return BadRequest();

        return Ok(dto);
    }

    //Add Drill Type
    //just admin
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> AddDrillType(AddDrillTypeDTO drillTypeDTO)
    {

        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();


        if (!ModelState.IsValid)
            return BadRequest();

        if (drillTypeDTO == null)
            return BadRequest();

        var Result = await _drillService.AddDrillType(drillTypeDTO);

        return Ok(Result);
    }



    //Remove Drill Type
    //just Admin
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> RemoveDrillType(int DrillTypeId)
    {
        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();

        var Result = await _drillService.RemoveDrillType(DrillTypeId);
        return Ok(Result);

    }

    #endregion



    #region Drill Age


    //Get All DrillAges
    [HttpGet("[Action]")]
    public async Task<ActionResult<List<DrillAgeReadonlyDTO>>> GetAllDrillAges()
    {

        var Drillages = await _drillService.GetAllDrillAges();
        return Ok(Drillages);

    }


    //Get Drill Age By Id
    [HttpGet("[Action]")]
    public async Task<ActionResult<DrillAgeReadonlyDTO>> GetDrillAgeById(int DrillAgeId)
    {

        var dto = await _drillService.GetDrillAgeById(DrillAgeId);
        if (dto == null)
            return BadRequest();

        return Ok(dto);

    }

    //Add Drill Age
    //just Admin
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> AddDrillAge(AddDrillAgeReadDTO drillAgeDTO)
    {


        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();


        if (!ModelState.IsValid)
            return BadRequest();

        if (drillAgeDTO == null)
            return BadRequest();


        var Result = await _drillService.AddDrilAge(drillAgeDTO);

        return Ok(Result);



    }


    //Remove Drill Age
    //Just Admin
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> RemoveDrillAge(int DrillAgeId)
    {

        var Result = await _drillService.RemoveDrillAge(DrillAgeId);

        return Ok(Result);
    }

    #endregion



}
