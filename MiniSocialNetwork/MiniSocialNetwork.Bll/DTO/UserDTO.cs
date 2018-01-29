using System;

namespace MiniSocialNetwork.Bll.DTO
{
    public class UserDTO
    {
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime Birthday { get; set; }
        public Boolean Sex { get; set; }
        public String Hometown { get; set; }
        public String Country { get; set; }
        public String Interests { get; set; }
        public String AboutMe { get; set; }
        public String FavoriteMusic { get; set; }
        public Byte[] Avatar { get; set; }
        public String Role { get; set; }
    }
}
