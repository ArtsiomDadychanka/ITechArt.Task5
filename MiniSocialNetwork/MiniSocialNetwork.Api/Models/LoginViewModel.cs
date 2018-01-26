using System;
using System.ComponentModel.DataAnnotations;

namespace MiniSocialNetwork.Api.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress(ErrorMessage = "Email is invalid.")]
        public String Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}