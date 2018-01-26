using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSocialNetwork.Dal.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public String Id { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime Birthday { get; set; }
        public Boolean Sex { get; set; }
        public String Hometown { get; set; }
        public String Country { get; set; }
        public String Interests { get; set; }
        public String AboutMe { get; set; }
        public String FavoriteMusic { get; set; }
        public byte[] Avatar { get; set; }

        public  virtual  ApplicationUser ApplicationUser { get; set; }
    }
}