using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.ValueObjects
{
    public sealed class MeasureValue : ValueObject<MeasureValue>
    {
        /// <summary>
        /// 完全コンストラクタパターン。コンストラクタで値設定後は、値を変更できないクラスのこと
        /// </summary>
        /// <param name="value"></param>
        public MeasureValue(float value)
        {
            Value = value;
        }

        /// <summary>
        /// 型はデータベースに合わせる。
        /// </summary>
        public float Value { get; }

        public string DisplayValue => Math.Round(Value, 2) + "℃";

        protected override bool EqualsCore(MeasureValue other)
        {
            return this.Value == other.Value;
        }
    }
}
