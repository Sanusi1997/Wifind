using System;
using Microsoft.EntityFrameworkCore;
using WiFind.Data;
using WiFind.Entities;
using WiFind.Services.Interfaces;

namespace WiFind.Services.WiFindServices
{
    public class WifiConnectionService : IWifiConnectionService
    {
        private readonly WiFindDbContext _context;
        public WifiConnectionService(WiFindDbContext context)
        {
            _context = context;
        }

        public WifiConnection AddConnection(WifiConnection wifiConnection)
        {
            if (wifiConnection == null)
            {
                throw new ArgumentNullException(nameof(wifiConnection));
            }
            // the repository fills the id (instead of using identity columns)
            wifiConnection.WifiConnectionId = Guid.NewGuid();
            wifiConnection.DateTimeCreated = DateTime.UtcNow;
            wifiConnection.IsExpired = false;
            wifiConnection.ConnectionStartTime = DateTime.UtcNow;
            wifiConnection.ConnectionEndTime = DateTime.UtcNow.AddHours(2);
            _context.WifiConnections.Add(wifiConnection);
            _context.SaveChanges();
            return wifiConnection;
        }
        public async Task<WifiConnection> GetWifiConnectionById(string connectionId)
        {
#pragma warning disable CS8603 // Possible null reference argument.
            return await _context.WifiConnections.AsQueryable().Where(c => c.WifiConnectionId.ToString() == connectionId).Include(u => u.WiFindUser).
                Include(w => w.Wifi).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference argument.
        }
        public async Task<WifiConnection> GetWifiConnectionByUserId(string userId)
        {
#pragma warning disable CS8603 // Possible null reference argument.
            return await _context.WifiConnections.AsQueryable().Where(c => c.WiFindUserId.ToString() == userId).Include(u => u.WiFindUser).
                Include(w => w.Wifi).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference argument.
        }

    }
}


