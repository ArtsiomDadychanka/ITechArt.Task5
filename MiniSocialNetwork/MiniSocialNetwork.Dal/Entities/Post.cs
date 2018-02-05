using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSocialNetwork.Dal.Entities
{
    public class Post
    {
        [Key]
        public String Id { get; set; }
        public String Text { get; set; }
        public Int32 Likes { get; set; }
        public DateTime PostedTime { get; set; }
        [ForeignKey("UserProfile")]
        public String AuthorId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
