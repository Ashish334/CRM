﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Server.Web.Api.DataObjects.User
{
    public class CreateUserRequestDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string MobileNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public List<string> Roles { get; set; }

        public int Status { get; set; }
    }
}
