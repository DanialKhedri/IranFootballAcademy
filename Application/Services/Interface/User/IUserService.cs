#region usings
using Application.DTOs.Tokens;
using Application.DTOs.User.UserLogInDTO;
using Application.DTOs.User.UserReadOnlyDTO;
using Application.DTOs.User.UserRegisterDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Application.Services.Interface.User;

public interface IUserService
{

    public Task<bool> IsPhoneNumberExist(string PhoneNumber);

    public Task<bool> Register(UserRegisterDTO userRegisterDTO);

    public Task<UserResultLogInDTO> LogIn(UserLogInDTO userLogInDTO);

    public Task<UserResultLogInDTO> LogInWithPhoneNumber(string PhoneNumber);

    public Task<AccessToken> RefreshToken(string RefreshToken);

    public Task<List<UserReadonlyDTO>> GetAllUsers();

    public Task<UserReadonlyDTO?> GetUserById(int UserId);

    public Task<bool> UserIsAdmin(int UserID);
    public Task<bool> UpdateUserAdminStatus(int userId, bool isAdmin);



}

