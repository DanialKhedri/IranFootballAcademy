#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Domain.IRepository.User;

public interface IUserRepository
{

    public Task<bool> IsPhoneNumberExist(string PhoneNumber);

    public Task<bool> Register(Entities.User user);


 

    public Task<Entities.User> LogIn(Entities.User user);
    public Task<Domain.Entities.User> LogInWithPhoneNumber(string PhoneNumber);

    public Task<string> RefreshToken(string RefreshToken);

    public Task<List<Entities.User>> GetAllUsers();
    public Task<Entities.User?> GetUserById(int UserId);

    public Task<bool> UpdateUserAdminStatus(int userId, bool isAdmin);

    public Task<bool> UserIsAdmin(int UserID);


}
