using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Server.Web.Api.User.DataObjects
{
    public class CreateUserRequestDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public List<string> Roles { get; set; }
    }
}
