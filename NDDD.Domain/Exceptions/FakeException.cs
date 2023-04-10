using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.Exceptions
{
    public sealed class FakeException : Exception
    {
        public FakeException(string message, Exception exception)
            :base(message, exception)
        {

        }
    }
}
