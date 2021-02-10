using System.ComponentModel.DataAnnotations;

namespace CRM.Server.Web.Api.Controllers.Resources
{
    public class UserCredentialsResource
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }
    }
}