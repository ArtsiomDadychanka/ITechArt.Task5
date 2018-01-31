using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialNetwork.Bll.DTO
{
    public class PostDTO
    {
        public String Id { get; set; } = Guid.Empty.ToString();
        public String AuthorName { get; set; } = String.Empty;
        public String AuthorId { get; set; } = Guid.Empty.ToString();
        public String Text { get; set; } = String.Empty;
        public DateTime PostedTime { get; set; } = DateTime.Now;
    }
}
