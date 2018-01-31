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
        public String AuthorName { get; set; } = String.Empty;
        public String Text { get; set; } = String.Empty;
        public DateTime PostedTime { get; set; } = DateTime.Now;
        [ForeignKey("UserProfile")]
        public String AuthorId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
