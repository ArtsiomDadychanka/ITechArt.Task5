using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;

namespace MiniSocialNetwork.Bll.Interfaces
{
    public interface IPostService
    {
        Task<OperationDetails> CreatePostAsync(PostDTO post);
        Task<OperationDetails> RemovePostAsync(string id);
        IEnumerable<PostDTO> GetPosts();
    }
}
