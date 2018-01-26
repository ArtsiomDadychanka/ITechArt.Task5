using System;
using System.ComponentModel.DataAnnotations;

namespace MiniSocialNetwork.Api.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public String Firstname { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public String Lastname { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress(ErrorMessage = "Email is invalid.")]
        public String Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
        public String RepeatPassword { get; set; }
    }
}