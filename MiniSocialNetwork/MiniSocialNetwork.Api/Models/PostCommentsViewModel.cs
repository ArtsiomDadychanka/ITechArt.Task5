using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniSocialNetwork.Api.Models
{
    public class PostCommentsViewModel
    {
        public DisplayedPostViewModel Post { get; set; }
        public IEnumerable<DisplayedCommentViewModel> Comments { get; set; }
    }
}