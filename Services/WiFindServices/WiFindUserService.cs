using System;
using WiFind.Data;
using WiFind.Entities;
using WiFind.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WiFind.Services.WiFindServices
{
    public class WiFindUserService : IWiFindUserService
    {
        private readonly WiFindDbContext _context;
        public WiFindUserService(WiFindDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public void AddUser(WiFindUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            // the repository fills the id (instead of using identity columns)
            user.WiFindUserId = Guid.NewGuid();
            user.DateCreated = DateTime.UtcNow;
            _context.WifindUsers.Add(user);
            _context.SaveChanges();

        }

        public async Task<IEnumerable<WiFindUser>> GetWiFindUsers()
        {
            return await _context.WifindUsers.AsQueryable().ToListAsync();
        }

        public async Task<WiFindUser> Update(WiFindUser user)
        {
            user.DateModified = DateTime.UtcNow;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;

        }
        public async Task<WiFindUser> GetUserByEmail(string email)
        {
#pragma warning disable CS8603 // Possible null reference argument.
            return await _context.WifindUsers.AsQueryable().Where(u => u.Email == email).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference argument.
        }
        public async Task<WiFindUser> GetUserById(string userId)
        {
#pragma warning disable CS8603 // Possible null reference argument.
            return await _context.WifindUsers.AsQueryable().Where(u => u.WiFindUserId.ToString() == userId).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference argument.
        }
        public async Task<WiFindUser> AuthenticateUser(string email, string password)
        {
#pragma warning disable CS8603 // Possible null reference argument.
            return await _context.WifindUsers.AsQueryable().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference argument.
        }
    }
}

