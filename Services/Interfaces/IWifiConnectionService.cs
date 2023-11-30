using System;
using WiFind.Entities;

namespace WiFind.Services.Interfaces
{
    public interface IWifiConnectionService
    {
        WifiConnection AddConnection(WifiConnection wifiConnection);
        Task<WifiConnection> GetWifiConnectionById(string connectionId);
        Task<WifiConnection> GetWifiConnectionByUserId(string userId);
    }
}

