using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.ValueObjects
{
    public sealed class AreaId: ValueObject<AreaId>
    {
        /// <summary>
        /// 完全コンストラクタパターン。コンストラクタで値設定後は、値を変更できないクラスのこと
        /// </summary>
        /// <param name="value"></param>
        public AreaId(int value)
        {
            Value = value;
        }

        /// <summary>
        /// 型はデータベースに合わせる。
        /// </summary>
        public int Value { get; }

        public string DisplayValue => Value.ToString().PadLeft(4, '0');

        protected override bool EqualsCore(AreaId other)
        {
            return this.Value == other.Value;
        }
    }
}
