using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniSocialNetwork.Api.Models
{
    public class PostViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Text)]
        public String AuthorName { get; set; }

        [Required(ErrorMessage = "AuthorId is required")]
        public String AuthorId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Text)]
        public String Text { get; set; }
    }
}