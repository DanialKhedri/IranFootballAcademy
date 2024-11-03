using DanCode_Blazor.Services.Base;

namespace Services.Base.interfaces;

public interface IUserService
{
    public Task<Response<List<UserReadonlyDTO>>> GetAllUsers();

    public Task<Response<AccessToken>> RefreshToken(string AccessToken);

    public Task<Response<bool>> IsAdmin(int UserId);

    public Task<Response<bool>> CourseIsBuyed(int UserId, int CourseId);
    public Task<Response<bool>> UpdateUserAdminStatus(int userId, bool isAdmin);


}

