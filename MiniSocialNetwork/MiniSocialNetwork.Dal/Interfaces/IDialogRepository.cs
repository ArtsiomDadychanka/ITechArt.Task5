using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.Entities;

namespace MiniSocialNetwork.Dal.Interfaces
{
    public interface IDialogRepository: IDisposable
    {
        Dialog CreateDialog(Dialog dialog);
        Task<Dialog> GetDialogByIdAsync(string id);
        IQueryable<Dialog> GetUserDialogs(string userId);
    }
}
