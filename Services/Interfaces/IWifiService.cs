using System;
using WiFind.Entities;

namespace WiFind.Services.Interfaces
{
    public interface IWifiService
    {
        void AddWifi(Wifi wifi);
        Task<Wifi> Update(Wifi wifi);
        Task<IEnumerable<Wifi>> GetWifis();
        Task<Wifi> GetWifiById(string wifiId);
        Task<Wifi> GetWifiByUserId(string userId);

    }
}

