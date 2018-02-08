using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;

namespace MiniSocialNetwork.Bll.Interfaces
{
    public interface IDialogService
    {
        Task<IEnumerable<DialogDTO>> GetUserDialogsAsync(string userId);
        Task<OperationDetails<DialogDTO>> GetDialogByIdAsync(string id);
        Task<OperationDetails<DialogDTO>> CreateDialogAsync(DialogDTO dialog);
    }
}
