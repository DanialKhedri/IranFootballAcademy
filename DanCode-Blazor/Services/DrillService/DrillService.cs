#region Usings
using Blazored.LocalStorage;
using DanCode_Blazor.Services.Base;
using DanCode_Blazor.Services.Base.interfaces;
using System;
using System.Collections.Generic;

#endregion

namespace DanCode_Blazor.Services.DrillService;

public class DrillService : BaseHttpService, IDrillService
{

    #region Ctor

    private readonly IClient client;
    public DrillService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {
        this.client = client;
    }

    #endregion


    #region Drill

    //Gets
    public async Task<Response<List<DrillReadonlyDTO>>> GetAllDrills()
    {

        Response<List<DrillReadonlyDTO>> response;

        try
        {


            var data = await client.GetAllDrillsAsync();


            response = new Response<List<DrillReadonlyDTO>>
            {
                Data = data.ToList(),
                Success = true,
            };
        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<List<DrillReadonlyDTO>>(exception);

        }

        return response;
    }

    //Get Drill By Id 
    public async Task<Response<DrillReadonlyDTO>> GetDrillById(int DrillId)
    {

        Response<DrillReadonlyDTO> response;
        try
        {

            var data = await client.GetDrillByIdAsync(DrillId);

            response = new Response<DrillReadonlyDTO>
            {
                Data = data,
                Success = true,
            };

        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<DrillReadonlyDTO>(exception);

        }
        return response;
    }

    //Edit Drill
    public async Task<Response<bool>> EditDrill(EditDrillDTO dto)
    {
        Response<bool> response;
        try
        {
            await GetBearerToken();
            var data = await client.EditDrillAsync(dto);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };

        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }
        return response;
    }

    //Add Drill 
    public async Task<Response<bool>> AddDrill(AddDrillDTO addDrillDTO)
    {
        Response<bool> response;
        try
        {
            await GetBearerToken();
            var data = await client.AddDrillAsync(addDrillDTO);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };
        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }
        return response;

    }

    //Remove Drill
    public async Task<Response<bool>> RemoveDrill(int DrillId)
    {

        Response<bool> response;

        try
        {
            await GetBearerToken();
            var data = await client.RemoveDrillAsync(DrillId);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };

        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }


        return response;


    }

    #endregion


    #region DrillAge

    //Get All Drill Ages
    public async Task<Response<List<DrillAgeReadonlyDTO>>> GetAllDrillAges()
    {


        Response<List<DrillAgeReadonlyDTO>> response;


        try
        {

            await GetBearerToken();
            var data = await client.GetAllDrillAgesAsync();

            response = new Response<List<DrillAgeReadonlyDTO>>
            {
                Data = data.ToList(),
                Success = true,
            };


        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<List<DrillAgeReadonlyDTO>>(exception);

        }

        return response;


    }

    //Add Drill Age
    public async Task<Response<bool>> AddDrillAge(AddDrillAgeReadDTO addDrillAgedto)
    {

        Response<bool> response;

        try
        {
            await GetBearerToken();
            var data = await client.AddDrillAgeAsync(addDrillAgedto);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };


        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }

        return response;

    }

    //Remove Drill Age
    public async Task<Response<bool>> RemoveDrillAge(int DrillAgeId)
    {

        Response<bool> response;

        try
        {
            await GetBearerToken();
            var data = await client.RemoveDrillAgeAsync(DrillAgeId);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };

        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }
        return response;
    }

    #endregion


    #region Drill Type

    //Get All Drill Ages
    public async Task<Response<List<DrillTypeReadOnlyDTO>>> GetAllDrillTypes()
    {


        Response<List<DrillTypeReadOnlyDTO>> response;


        try
        {

            await GetBearerToken();
            var data = await client.GetAllDrillTypesAsync();

            response = new Response<List<DrillTypeReadOnlyDTO>>
            {
                Data = data.ToList(),
                Success = true,
            };


        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<List<DrillTypeReadOnlyDTO>>(exception);

        }

        return response;


    }

    //Add Drill Age
    public async Task<Response<bool>> AddDrillType(AddDrillTypeDTO addDrillTypeDTO)
    {

        Response<bool> response;

        try
        {
            await GetBearerToken();
            var data = await client.AddDrillTypeAsync(addDrillTypeDTO);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };


        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }

        return response;

    }

    //Remove Drill Age
    public async Task<Response<bool>> RemoveDrillType(int DrillTypeId)
    {

        Response<bool> response;

        try
        {
            await GetBearerToken();
            var data = await client.RemoveDrillTypeAsync(DrillTypeId);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };

        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }
        return response;
    }




    #endregion


}
