using System;

namespace NDDD.Domain.Exceptions
{
    public sealed class DataNotExixtsException : ExceptionBase
    {
        public DataNotExixtsException()
            :base("データがありません")
        {

        }

        public override ExceptionKind Kind => ExceptionKind.Info;
    }
}
