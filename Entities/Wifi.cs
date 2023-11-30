using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WiFind.Entities
{
    public class Wifi
    {
        [Key]
        public Guid WifiId { get; set; }
        public string WifiName { get; set; } = "";
        public string Price { get; set; } = "";
        public string Location { get; set; } = "";
        public string Speed { get; set; } = "";
        public int NoOfUsers { get; set; }
        public double AmountEarned { get; set; }
        public string Password { get; set; } = "";
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        [ForeignKey("WiFindUserId")]
        public WiFindUser? WiFindUser { get; set; }
        public Guid WiFindUserId { get; set; }

    }
}

