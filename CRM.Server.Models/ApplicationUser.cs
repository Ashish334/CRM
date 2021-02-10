using System;
using System.Collections.Generic;

namespace CRM.Server.Models
{
    public class ApplicationUser 
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string MobileNumber { get; set; }

        public bool MobileNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime CreatedDateTimeUtc { get; set; }

        public DateTime UpdatedDateTimeUtc { get; set; }

        public int Status { get; set; }

        public  List<string> Roles { get; set; }
    }
}
