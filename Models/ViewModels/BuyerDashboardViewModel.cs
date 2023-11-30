using System;
using WiFind.Entities;

namespace WiFind.Models.ViewModels
{
    public class BuyerDashboardViewModel
    {
        public WiFindUser? user { get; set; }
        public List<Wifi>? wifi { get; set; }
    }
}

