using System;
using System.Collections.Generic;

namespace MiniSocialNetwork.Bll.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public String Id { get; set; } = Guid.NewGuid().ToString();
        public String Firstname { get; set; } = String.Empty;
        public String Lastname { get; set; } = String.Empty;
        public String Email { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime Birthday { get; set; } = DateTime.Now;
        public Boolean Sex { get; set; } = false;
        public String Hometown { get; set; } = String.Empty;
        public String Country { get; set; } = String.Empty;
        public String Interests { get; set; } = String.Empty;
        public String AboutMe { get; set; } = String.Empty;
        public String FavoriteMusic { get; set; } = String.Empty;
        public Byte[] Avatar { get; set; } = null;
        public String Role { get; set; } = Shared.Constants.RolesNames.User;

        public IEnumerable<PostDTO> Posts { get; set; }
    }
}
