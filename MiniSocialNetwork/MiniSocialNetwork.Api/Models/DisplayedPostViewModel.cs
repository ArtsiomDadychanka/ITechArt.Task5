using System;

namespace MiniSocialNetwork.Api.Models
{
    public class DisplayedPostViewModel
    {
        public String AuthorName { get; set; }
        public String Text { get; set; }
        public DateTime PostedDate { get; set; }
        public Int32 LikeCounts { get; set; }
        public Int32 CommentCounts { get; set; }
    }
}