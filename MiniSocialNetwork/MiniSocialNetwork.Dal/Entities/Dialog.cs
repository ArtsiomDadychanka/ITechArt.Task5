using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSocialNetwork.Dal.Entities
{
    public class Dialog
    {
        [Key]
        public string Id { get; set; }
        //[ForeignKey(nameof(UserProfile))]
        public string OneUserId { get; set; }
        //[ForeignKey(nameof(UserProfile))]
        public string OtherUserId { get; set; }

        [ForeignKey(nameof(OneUserId))]
        public UserProfile OneUserProfile { get; set; }
        [ForeignKey(nameof(OtherUserId))]
        public UserProfile OtherUserProfile { get; set; }
    }
}
