using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniSocialNetwork.Api.Models
{
    public class DisplayedUserViewModel
    {
        public String Id { get; set; } = Guid.NewGuid().ToString();
        public String Firstname { get; set; } = String.Empty;
        public String Lastname { get; set; } = String.Empty;
        public String Username { get; set; }
        public String Email { get; set; } = String.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime Birthday { get; set; } = DateTime.Now;
        public Boolean Sex { get; set; } = false;
        public String Hometown { get; set; } = String.Empty;
        public String Country { get; set; } = String.Empty;
        public String Interests { get; set; } = String.Empty;
        public String AboutMe { get; set; } = String.Empty;
        public String FavoriteMusic { get; set; } = String.Empty;
        public Byte[] Avatar { get; set; } = null;

        public IEnumerable<DisplayedPostViewModel> Posts { get; set; }

    }
}