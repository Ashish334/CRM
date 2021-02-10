using System.ComponentModel.DataAnnotations;

namespace CRM.Server.Web.Api.DataObjects.User
{
    public class ResetPasswordRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Token { get; set; }

    }
}
