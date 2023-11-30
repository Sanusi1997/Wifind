using System;
using WiFind.Entities;

namespace WiFind.Models.ViewModels
{
    public class PaymentPageViewModel
    {
        public Wifi? wifi { get; set; }
        public WiFindUser? wifiUser { get; set; }
        public PaymentDTO? payment { get; set; }
    }
}

