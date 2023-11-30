using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WiFind.Entities
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }
        public double PaymentAmount { get; set; }
        public bool IsVerified { get; set; }
        [ForeignKey("WiFindUserId")]
        public WiFindUser? WiFindUser { get; set; }
        public Guid WiFindUserId { get; set; }
        [ForeignKey("WifiId")]
        public Wifi? Wifi { get; set; }
        public Guid WifiId { get; set; }
        public DateTime? DateTimeCreated { get; set; }
        public DateTime? DateTimeModified { get; set; }

    }
}

