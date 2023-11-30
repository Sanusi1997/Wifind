using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WiFind.Entities
{
    public class WiFindUser
    {
        [Key]
        public Guid WiFindUserId { get; set; }
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string UserType { get; set; } = "";
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateTimeCreated { get; set; }
        public DateTime? DateTimeModified { get; set; }

    }
}

