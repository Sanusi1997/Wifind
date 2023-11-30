using System;
namespace WiFind.Models
{
    public class PaymentDTO
    {
        public string PaymentAmount { get; set; } = "";
        public Guid WifiId { get; set; }
        public Guid WifindUserId { get; set; }

    }
}

