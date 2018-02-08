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
    public class DialogRepository : Repository, IDialogRepository
    {
        public DialogRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public Dialog CreateDialog(Dialog dialog)
        {
            Dialog createdDialog = Database.Dialogs.Add(dialog);

            return createdDialog;
        }

        public async Task<Dialog> GetDialogByIdAsync(string id)
        {
            Dialog findedDialog = await Database.Dialogs.FindAsync(id);

            return findedDialog;
        }

        public IQueryable<Dialog> GetUserDialogs(string userId)
        {
            IQueryable<Dialog> userDialogs = Database.Dialogs.Where(d => d.OneUserId == userId).AsNoTracking();

            return userDialogs;
        }
    }
}
