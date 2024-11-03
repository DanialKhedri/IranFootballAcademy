#region Usings
using Application.Security;
using Application.Utilities.JWT;
using Azure.Core;
using Domain.Entities;
using Domain.IRepository.User;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Infrastructure.Repository.User;

public class UserRepository : IUserRepository
{

    #region Ctor

    private readonly DataContext _dataContext;
    private readonly IConfiguration _configuration;

    public UserRepository(DataContext dataContext, IConfiguration configuration)
    {
        _dataContext = dataContext;
        _configuration = configuration;

    }


    #endregion

    //Register
    public async Task<bool> IsPhoneNumberExist(string PhoneNumber)
    {

        bool IsExist = _dataContext.Users.Any(u => u.PhoneNumber == PhoneNumber);
        return IsExist;

    }

    public async Task<bool> Register(Domain.Entities.User user)
    {

        if (user != null)
        {

            try
            {
                user.Password = PasswordHasher.EncodePasswordMd5(user.Password);

                await _dataContext.Users.AddAsync(user);
                await _dataContext.SaveChangesAsync();

                return true;
            }

            catch
            {
                return false;
            }


        }
        return false;

    }

    public async Task<bool> UpdateUserAdminStatus(int userId, bool isAdmin)
    {

        try
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return false;

            user.IsAdmin = isAdmin;

            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();

            return true;
        }
        catch
        {

            return false;
        }


    }



    //LogIn
    public async Task<Domain.Entities.User> LogIn(Domain.Entities.User user)
    {

        if (user != null)
        {
            var OriginUser = await _dataContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == user.PhoneNumber &&
                                    u.Password == PasswordHasher.EncodePasswordMd5(user.Password));
            if (OriginUser == null)
                return null;


            // تولید Access Token
            var Token = await JWTTokenService.GenerateToken(OriginUser, _configuration);

            // تولید Refresh Token
            var refreshToken =  JWTTokenService.GenerateRefreshToken();

            // تنظیم زمان انقضای Refresh Token (مثلاً 10 روز)
            var refreshTokenExpiryTime = DateTime.UtcNow.AddDays(10);



            // ذخیره Refresh Token در دیتابیس
            OriginUser.RefreshToken = refreshToken;
            OriginUser.RefreshTokenExpiryTime = refreshTokenExpiryTime; // اضافه شده

            _dataContext.Users.Update(OriginUser);
            await _dataContext.SaveChangesAsync();

            Domain.Entities.User LogUser = new Domain.Entities.User()
            {
                Id = OriginUser.Id,
                JWTToken = Token,
                RefreshToken = refreshToken,
                PhoneNumber = OriginUser.PhoneNumber,
                FullName = OriginUser.FullName,
                Password = OriginUser.Password,
            };


            return LogUser;


        }
        else
            return null;
    }


    //LogIn With PhoneNumber
    public async Task<Domain.Entities.User> LogInWithPhoneNumber(string PhoneNumber)
    {

        if (!string.IsNullOrEmpty(PhoneNumber))
        {
            var OriginUser = await _dataContext.Users.FirstOrDefaultAsync( u=> u.PhoneNumber == PhoneNumber);
                                   
            if (OriginUser == null)
                return null;


            // تولید Access Token
            var Token = await JWTTokenService.GenerateToken(OriginUser, _configuration);

            // تولید Refresh Token
            var refreshToken = JWTTokenService.GenerateRefreshToken();

            // تنظیم زمان انقضای Refresh Token (مثلاً 30 روز)
            var refreshTokenExpiryTime = DateTime.UtcNow.AddMonths(12);



            // ذخیره Refresh Token در دیتابیس
            OriginUser.RefreshToken = refreshToken;
            OriginUser.RefreshTokenExpiryTime = refreshTokenExpiryTime; // اضافه شده

            _dataContext.Users.Update(OriginUser);
            await _dataContext.SaveChangesAsync();

            Domain.Entities.User LogUser = new Domain.Entities.User()
            {
                Id = OriginUser.Id,
                JWTToken = Token,
                RefreshToken = refreshToken,
                PhoneNumber = OriginUser.PhoneNumber,
                FullName = OriginUser.FullName,
                Password = OriginUser.Password,
            };


            return LogUser;


        }
        else
            return null;
    }

    //Refresh Token
    public async Task<string> RefreshToken(string refreshToken)
    {
        // بررسی صحت Refresh Token در دیتابیس
        var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

        if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return null; // یا خطا بازگردانید
        }

        // تولید Access Token جدید
        var newAccessToken = await JWTTokenService.GenerateToken(user, _configuration);

        // بازگرداندن Access Token جدید
        return newAccessToken;


    }


    //Get All
    public async Task<List<Domain.Entities.User>> GetAllUsers()
    {
        var Users = await _dataContext.Users.ToListAsync();
        return Users;
    }

    //Get By Id
    public async Task<Domain.Entities.User?> GetUserById(int UserId)
    {
        return await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == UserId);
    }



    //User Is Admin?
    public async Task<bool> UserIsAdmin(int UserID)
    {


        try
        {
            var User = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == UserID);

            if (User != null)
                return User.IsAdmin;

            else
                return false;



        }
        catch
        {
            return false;

        }


    }


}
