using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Exceptions;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Bll.Services
{
    public class PostService : Service, IPostService
    {
        public PostService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<OperationDetails> CreatePostAsync(PostDTO post)
        {
            Uow.PostRepository.Create(Mapper.Map<PostDTO, Post>(post));

            await Uow.SaveAsync();

            return new OperationDetails(true, "Post created successfully.", "");
        }

        public async Task<IEnumerable<PostDTO>> GetPostsAsync()
        {
            IEnumerable<Post> posts = await Uow.PostRepository.GetAll().ToListAsync();
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(posts);
        }

        public async Task<IEnumerable<PostDTO>> GetUsersPostsAsync(String id)
        {
            IEnumerable<Post> posts = await Uow.PostRepository.GetUsersPosts(id).ToListAsync();
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(posts);
        }

        public async Task<OperationDetails> RemovePostAsync(String id)
        {
            try
            {
                Uow.PostRepository.DeleteAsync(id);
            }
            catch (PostNotFoundException e)
            {
                return new OperationDetails(false, e.Message, "");
            }

            await Uow.SaveAsync();

            return new OperationDetails(true, "Post deleted successfully.", "");
        }

        public async Task<OperationDetails> Like(String postId)
        {
            Uow.PostRepository.Like(postId);

            await Uow.SaveAsync();

            return new OperationDetails(true, "Post liked successfully.", "");
        }

        public async Task<OperationDetails> Unlike(String postId)
        {
            Uow.PostRepository.Unlike(postId);
            await Uow.SaveAsync();

            return new OperationDetails(true, "Post unliked successfully.", "");
        }
    }
}
