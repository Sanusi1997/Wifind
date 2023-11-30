using System;
using WiFind.Data;
using WiFind.Entities;
using WiFind.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WiFind.Services.WiFindServices
{
    public class WifiService : IWifiService
    {
        private readonly WiFindDbContext _context;
        public WifiService(WiFindDbContext context)
        {
            _context = context;
        }

        public void AddWifi(Wifi wifi)
        {
            if (wifi == null)
            {
                throw new ArgumentNullException(nameof(wifi));
            }
            // the repository fills the id (instead of using identity columns)
            wifi.WifiId = Guid.NewGuid();
            wifi.DateCreated = DateTime.UtcNow;
            _context.Wifis.Add(wifi);
            _context.SaveChanges();
        }

        public async Task<Wifi> GetWifiById(string wifiId)
        {
#pragma warning disable CS8603 // Possible null reference argument.
            return await _context.Wifis.AsQueryable().Where(w => w.WifiId.ToString() == wifiId).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference argument.
        }
        public async Task<Wifi> GetWifiByUserId(string userId)
        {
#pragma warning disable CS8603 // Possible null reference argument.
            return await _context.Wifis.AsQueryable().Where(w => w.WiFindUserId.ToString() == userId).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference argument.
        }
        public async Task<IEnumerable<Wifi>> GetWifis()
        {
            return await _context.Wifis.AsQueryable().Include(w => w.WiFindUser).ToListAsync();
        }

        public async Task<Wifi> Update(Wifi wifi)
        {
            wifi.DateModified = DateTime.UtcNow;
            _context.Entry(wifi).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return wifi;

        }
    }
}

