using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRouteBeheer
{
    public class NetworkException : Exception
    {
        public NetworkException()
        {
        }

        public NetworkException(string? message) : base(message)
        {
        }

        public NetworkException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
