using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.Exceptions
{
    public sealed class FakeException : ExceptionBase
    {
        public FakeException(string message, Exception exception)
            :base(message, exception)
        {

        }

        public override ExceptionKind Kind => ExceptionKind.Error;
    }
}
