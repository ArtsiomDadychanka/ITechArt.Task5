using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.EF;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Dal.Repositories
{
    public  class Repository : IRepository
    {
        protected Repository(ApplicationContext dbContext)
        {
            Database = dbContext;
        }

        public ApplicationContext Database { get; set; }

        #region Dispose
        public void Dispose()
        {
            ((IDisposable)Database).Dispose();
        }
        #endregion
    }
}
