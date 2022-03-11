using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Application.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message = null, Exception inner = null) : base(message, inner)
        {
        }
    }
}
