using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.Entities;

namespace MiniSocialNetwork.Dal.Interfaces
{
    public interface IMessagesRepository : IDisposable
    {
        IQueryable<Message> GetMessagesByDialogId(string dialogId);
        Message CreateMessage(Message message);
    }
}
