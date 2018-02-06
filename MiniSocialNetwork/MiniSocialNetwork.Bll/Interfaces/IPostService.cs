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
        Task<OperationDetails<PostDTO>> CreatePostAsync(PostDTO post);
        Task<OperationDetails> RemovePostAsync(String id);
        Task<IEnumerable<PostDTO>> GetPostsAsync();
        Task<IEnumerable<PostDTO>> GetUsersPostsAsync(String id);
        Task<OperationDetails> Like(String postId);
        Task<OperationDetails> Unlike(String postId);
    }
}
