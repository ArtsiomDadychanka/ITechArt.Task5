using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Bll.Services
{
    public class Service : IService
    {
        protected IUnitOfWork Uow;

        protected Service(IUnitOfWork unitOfWork)
        {
            Uow = unitOfWork;
        }
    }
}
