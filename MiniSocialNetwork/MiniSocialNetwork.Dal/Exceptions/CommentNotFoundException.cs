using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MiniSocialNetwork.Dal.Exceptions
{
    [Serializable]
    public class CommentNotFoundException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CommentNotFoundException() : base("Comment not found.")
        {
        }

        public CommentNotFoundException(string message) : base(message)
        {
        }

        public CommentNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CommentNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
