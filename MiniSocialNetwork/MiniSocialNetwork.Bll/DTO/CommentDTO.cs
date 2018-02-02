using System;

namespace MiniSocialNetwork.Bll.DTO
{
    public class CommentDTO
    {
        public String Id { get; set; } = Guid.NewGuid().ToString();
        public String Text { get; set; } = String.Empty;
        public DateTime PostedTime { get; set; } = DateTime.Now;

        public String PostId { get; set; } = Guid.NewGuid().ToString();

        public String AuthorId { get; set; } = Guid.Empty.ToString();
        public String AuthorName { get; set; } = String.Empty;
    }
}
