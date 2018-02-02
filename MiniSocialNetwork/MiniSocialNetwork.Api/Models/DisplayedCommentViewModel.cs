using System;

namespace MiniSocialNetwork.Api.Models
{
    public class DisplayedCommentViewModel
    {
        public String Id { get; set; }
        public String AuthorName { get; set; }
        public String Text { get; set; }
        public DateTime PostedDate { get; set; }
    }
}