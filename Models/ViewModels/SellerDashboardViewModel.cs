using System;
using WiFind.Entities;

namespace WiFind.Models.ViewModels
{
    public class SellerDashboardViewModel
    {
        public WiFindUser? user { get; set; }
        public Wifi? wifi { get; set; }
    }
}

