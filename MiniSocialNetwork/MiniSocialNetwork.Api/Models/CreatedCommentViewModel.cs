using System;
using System.ComponentModel.DataAnnotations;

namespace MiniSocialNetwork.Api.Models
{
    public class CreatedCommentViewModel
    {
        [Required(ErrorMessage = "AuthorId is required")]
        public String AuthorId { get; set; }

        [Required(ErrorMessage = "Text of comment is required.")]
        [MinLength(1, ErrorMessage = "Text of comment is empty.")]
        [DataType(DataType.Text)]
        public String Text { get; set; }

        [Required(ErrorMessage = "Post id is required.")]
        public String PostId { get; set; }
    }
}