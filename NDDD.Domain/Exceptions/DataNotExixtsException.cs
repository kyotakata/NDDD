using System;

namespace NDDD.Domain.Exceptions
{
    /// <summary>
    /// データなし例外クラス
    /// </summary>
    public sealed class DataNotExixtsException : ExceptionBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DataNotExixtsException()
            :base("データがありません")
        {

        }

        /// <summary>
        /// 区分
        /// </summary>
        public override ExceptionKind Kind => ExceptionKind.Info;
    }
}
