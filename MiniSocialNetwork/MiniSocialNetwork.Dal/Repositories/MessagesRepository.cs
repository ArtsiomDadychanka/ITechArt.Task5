using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.EF;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Dal.Repositories
{
    public class MessagesRepository : Repository, IMessagesRepository
    {
        public MessagesRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Message> GetMessagesByDialogId(string dialogId)
        {
             return Database.Messages.Where(m => m.DialogId == dialogId).AsNoTracking();
        }

        public Message CreateMessage(Message message)
        {
            Message createdMessage = Database.Messages.Add(message);
            return createdMessage;
        }
    }
}
