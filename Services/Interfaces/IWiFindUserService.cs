using System;
using WiFind.Entities;

namespace WiFind.Services.Interfaces
{
    public interface IWiFindUserService
    {
        void AddUser(WiFindUser user);
        Task<WiFindUser> Update(WiFindUser user);
        Task<IEnumerable<WiFindUser>> GetWiFindUsers();
        Task<WiFindUser> GetUserByEmail(string email);
        Task<WiFindUser> GetUserById(string userId);
        Task<WiFindUser> AuthenticateUser(string email, string password);

    }
}

