using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;

namespace MiniSocialNetwork.Bll.Interfaces
{
    public interface IMessageService
    {
        Task<OperationDetails<MessageDTO>> CreateMessage(MessageDTO messageDto);
        Task<IEnumerable<MessageDTO>> GetMessagesByDialogId(string dialogId);
    }
}
