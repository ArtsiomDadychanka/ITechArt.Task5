using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSocialNetwork.Dal.Entities
{
    public class Message
    {
        [Key]
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        [ForeignKey(nameof(Dialog))]
        public string DialogId { get; set; }

        public virtual Dialog Dialog { get; set; }
    }
}
