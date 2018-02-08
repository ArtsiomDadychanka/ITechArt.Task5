using System;

namespace MiniSocialNetwork.Bll.DTO
{
    public class MessageDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Text { get; set; } = string.Empty;
        public DateTime Time { get; set; } = DateTime.Now;
        public string DialogId { get; set; } = Guid.NewGuid().ToString();
    }
}
