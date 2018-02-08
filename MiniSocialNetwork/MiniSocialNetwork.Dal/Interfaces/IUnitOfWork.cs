using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.Identity;

namespace MiniSocialNetwork.Dal.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IUserProfileManager ProfileManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IPostRepository PostRepository { get; }
        ICommentRepository CommentRepository { get; }
        IUserRepository UserRepository { get; }
        IDialogRepository DialogRepository { get; }
        IMessagesRepository MessagesRepository { get; }
        Task SaveAsync();
    }
}
