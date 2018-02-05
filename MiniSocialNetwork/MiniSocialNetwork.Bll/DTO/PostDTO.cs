using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialNetwork.Bll.DTO
{
    public class PostDTO
    {
        public PostDTO()
        {
            
        }

        public String Id { get; set; } = Guid.NewGuid().ToString();
        public String Text { get; set; } = String.Empty;
        public Int32 Likes { get; set; } = 0;
        public DateTime PostedTime { get; set; } = DateTime.Now;

        public String AuthorId { get; set; } = Guid.Empty.ToString();
        public String AuthorName { get; set; } = String.Empty;

        public IEnumerable<CommentDTO> Comments { get; set; }
    }
}
