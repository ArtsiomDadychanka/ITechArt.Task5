using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialNetwork.Dal.Entities
{
    public class Post
    {
        [Key]
        public String Id { get; set; } = Guid.Empty.ToString();
        public String Text { get; set; } = String.Empty;
        public Int32 Likes { get; set; } = 0;
        public DateTime PostedTime { get; set; } = DateTime.Now;
        [ForeignKey("UserProfile")]
        public String AuthorId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Comments = new List<Comment>();
        }

    }
}
