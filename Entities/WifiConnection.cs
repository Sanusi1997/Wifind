using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WiFind.Entities
{
    public class WifiConnection
    {
        [Key]
        public Guid WifiConnectionId { get; set; }
        public DateTime? ConnectionStartTime { get; set; }
        public DateTime? ConnectionEndTime { get; set; }
        public bool IsExpired { get; set; }
        public DateTime? DateTimeCreated { get; set; }
        public DateTime? DateTimeModified { get; set; }
        [ForeignKey("WifiId")]
        public Wifi? Wifi { get; set; }
        public Guid WifiId { get; set; }
        [ForeignKey("WiFindUserId")]
        public WiFindUser? WiFindUser { get; set; }
        public Guid WiFindUserId { get; set; }

    }
}

