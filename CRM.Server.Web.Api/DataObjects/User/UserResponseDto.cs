﻿using System;
using System.Collections.Generic;

namespace CRM.Server.Web.Api.DataObjects.User
{
    public class UserResponseDto
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string Picture { get; set; }

        public List<string> Roles { get; set; }

        public int Status { get; set; }



        public string Role {
            get
            { 
                if (Roles != null && Roles.Count > 0)
                {
                    return Roles[0];
                }
                return "";
            } 
        }

        public DateTime CreatedDateTimeUtc { get; set; }

        public DateTime UpdatedDateTimeUtc { get; set; }
    }
}
