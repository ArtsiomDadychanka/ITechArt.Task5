using System;
using System.ComponentModel.DataAnnotations;

namespace MiniSocialNetwork.Api.Models
{
    public class CreatedPostViewModel
    {
        [Required(ErrorMessage = "AuthorId is required")]
        public String AuthorId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [MinLength(1, ErrorMessage = "Text of post is empty.")]
        [DataType(DataType.Text)]
        public String Text { get; set; }
    }
}