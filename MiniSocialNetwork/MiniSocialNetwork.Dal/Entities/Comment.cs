using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSocialNetwork.Dal.Entities
{
    public class Comment
    {
        [Key]
        public String Id { get; set; }
        public String Text { get; set; }
        public DateTime PostedTime { get; set; }
        [ForeignKey("Post")]
        public String PostId { get; set; }
        [ForeignKey("UserProfile")]
        public String AuthorId { get; set; }

        public virtual Post Post { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
