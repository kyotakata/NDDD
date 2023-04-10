using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.ValueObjects
{
    public sealed class MeasureDate : ValueObject<MeasureDate>
    {
        /// <summary>
        /// 完全コンストラクタパターン。コンストラクタで値設定後は、値を変更できないクラスのこと
        /// </summary>
        /// <param name="value"></param>
        public MeasureDate(DateTime value)
        {
            Value = value;
        }

        /// <summary>
        /// 型はデータベースに合わせる。
        /// </summary>
        public DateTime Value { get; }

        public string DisplayValue => Value.ToString("yyyy/MM/dd HH:mm:ss");

        protected override bool EqualsCore(MeasureDate other)
        {
            return this.Value == other.Value;
        }
    }
}
