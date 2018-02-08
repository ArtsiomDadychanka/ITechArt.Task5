using System;

namespace MiniSocialNetwork.Bll.DTO
{
    public class DialogDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string OneUserId { get; set; } = Guid.NewGuid().ToString();
        public string OtherUserId { get; set; } = Guid.NewGuid().ToString();
    }
}
