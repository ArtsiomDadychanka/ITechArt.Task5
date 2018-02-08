using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSocialNetwork.Dal.Entities
{
    public class Post
    {
        [Key]
        public string Id { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public DateTime PostedTime { get; set; }
        [ForeignKey(nameof(UserProfile))]
        public string AuthorId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
