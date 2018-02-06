using System;
using System.Collections.Generic;

namespace MiniSocialNetwork.Api.Models
{
    public class DisplayedPostViewModel
    {
        public DisplayedPostViewModel()
        {
        }

        public String Id { get; set; }
        public String AuthorName { get; set; }
        public String Text { get; set; }
        public DateTime PostedDate { get; set; }
        public Int32 LikeCounts { get; set; }

        //public IEnumerable<DisplayedCommentViewModel> Comments { get; set; }
    }
}