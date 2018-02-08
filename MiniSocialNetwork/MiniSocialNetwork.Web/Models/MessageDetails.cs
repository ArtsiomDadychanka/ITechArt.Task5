using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniSocialNetwork.Web.Models
{
    public class MessageDetails
    {
        public int FromUserId { get; set; }
        public string FromUserName { get; set; }
        public int ToUserId { get; set; }
        public string ToUserName { get; set; }
        public string Message { get; set; }
    }
}