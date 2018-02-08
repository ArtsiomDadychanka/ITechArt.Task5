using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSocialNetwork.Dal.Entities
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime PostedTime { get; set; }
        [ForeignKey(nameof(Post))]
        public string PostId { get; set; }
        [ForeignKey(nameof(UserProfile))]
        public string AuthorId { get; set; }

        public virtual Post Post { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
