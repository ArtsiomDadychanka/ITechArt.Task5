using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSocialNetwork.Dal.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }
        public string Firstname { get; set; } 
        public string Lastname { get; set; } 
        public DateTime RegistrationDate { get; set; } 
        public DateTime Birthday { get; set; } 
        public bool Sex { get; set; } 
        public string Hometown { get; set; }
        public string Country { get; set; }
        public string Interests { get; set; }
        public string AboutMe { get; set; }
        public string FavoriteMusic { get; set; } 
        public byte[] Avatar { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Dialog> Dialogs { get; set; }
    }
}