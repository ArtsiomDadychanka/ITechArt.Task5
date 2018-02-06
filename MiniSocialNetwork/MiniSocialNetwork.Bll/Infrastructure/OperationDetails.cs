using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialNetwork.Bll.Infrastructure
{
    public class OperationDetails
    {
        public OperationDetails(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }
        public bool Succedeed { get; }
        public string Message { get; }
        public string Property { get; }
    }

    public class OperationDetails<T> : OperationDetails  where T : class
    {
        public OperationDetails(bool succedeed, string message, string prop, T data) : base(succedeed, message, prop)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
