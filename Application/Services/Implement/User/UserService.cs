#region Usings.
using Application.DTOs.Tokens;
using Application.DTOs.User.UserLogInDTO;
using Application.DTOs.User.UserReadOnlyDTO;
using Application.DTOs.User.UserRegisterDTO;
using Application.Services.Interface.User;
using AutoMapper;
using Domain.IRepository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Application.Services.Implement.User;

public class UserService : IUserService
{

    #region Ctor

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;


    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;

    }


    #endregion


    public async Task<bool> IsPhoneNumberExist(string PhoneNumber)
    {

        return await _userRepository.IsPhoneNumberExist(PhoneNumber);


    }


    public async Task<bool> Register(UserRegisterDTO userRegisterDTO)
    {
        if (userRegisterDTO != null)
        {

            var user = _mapper.Map<Domain.Entities.User>(userRegisterDTO);
            return await _userRepository.Register(user);

        }
        else
        {
            return false;
        }




    }

    public async Task<UserResultLogInDTO> LogIn(UserLogInDTO userLogInDTO)
    {
        if (userLogInDTO != null)
        
        
        {

            var user = _mapper.Map<Domain.Entities.User>(userLogInDTO);

            var LogedUser = await _userRepository.LogIn(user);

            if (LogedUser != null)
            {

                UserResultLogInDTO resultLogInDTO = new UserResultLogInDTO
                {
                    Id = LogedUser.Id,
                    JWTToken = LogedUser.JWTToken,
                    RefreshToken = LogedUser.RefreshToken,
                    PhoneNumber = LogedUser.PhoneNumber,
                    FullName = LogedUser.FullName,
                };

                return resultLogInDTO;

            }
            else
                return null;

        }
        else
            return null;
    }

    public async Task<UserResultLogInDTO> LogInWithPhoneNumber(string PhoneNumber)
    {

        if (!string.IsNullOrEmpty(PhoneNumber))
        {
            var LogedUser = await _userRepository.LogInWithPhoneNumber(PhoneNumber);

            if (LogedUser != null)
            {

                UserResultLogInDTO resultLogInDTO = new UserResultLogInDTO
                {
                    Id = LogedUser.Id,
                    JWTToken = LogedUser.JWTToken,
                    RefreshToken = LogedUser.RefreshToken,
                    PhoneNumber = LogedUser.PhoneNumber,
                    FullName = LogedUser.FullName,
                };

                return resultLogInDTO;

            }
            else
                return null;

        }
        else
            return null;
    }


    public async Task<AccessToken> RefreshToken(string RefreshToken)
    {

        var accesstoken = await _userRepository.RefreshToken(RefreshToken);

        if (accesstoken != null)
        {
            AccessToken accessToken = new AccessToken()
            {
                Token = accesstoken,
            };

            return accessToken;

        }
        else
            return null;

    }


    public async Task<List<UserReadonlyDTO>> GetAllUsers()
    {

        var Users = await _userRepository.GetAllUsers();

        List<UserReadonlyDTO> userReadonlyDTOs = new List<UserReadonlyDTO>();

        if (Users != null && Users.Count != 0)
        {


            foreach (var item in Users)
            {
                var temp = _mapper.Map<UserReadonlyDTO>(item);
                userReadonlyDTOs.Add(temp);
            }


        }

        return userReadonlyDTOs;

    }


    public async Task<UserReadonlyDTO?> GetUserById(int UserId)
    {

        var user = await _userRepository.GetUserById(UserId);

        if (user != null)
        {
            var dto = _mapper.Map<UserReadonlyDTO>(user);

            return dto;
        }
        else
            return null;
    }

    public async Task<bool> UpdateUserAdminStatus(int userId, bool isAdmin)
    { 

        return await _userRepository.UpdateUserAdminStatus(userId, isAdmin);

    }

    public async Task<bool> UserIsAdmin(int UserID)
    {

        return await _userRepository.UserIsAdmin(UserID);

    }

}
