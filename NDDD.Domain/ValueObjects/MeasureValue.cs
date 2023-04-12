using DDD.Domain.ValueObjects;
using NDDD.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.ValueObjects
{
    /// <summary>
    /// 計測値
    /// </summary>
    public sealed class MeasureValue : ValueObject<MeasureValue>
    {
        /// <summary>
        /// コンストラクタ。完全コンストラクタパターン。コンストラクタで値設定後は、値を変更できないクラスのこと
        /// </summary>
        /// <param name="value"></param>
        public MeasureValue(float value)
        {
            Value = value;
        }

        /// <summary>
        /// 値。型はデータベースに合わせる。
        /// </summary>
        public float Value { get; }

        /// <summary>
        /// 表示する値
        /// </summary>
        public string DisplayValue => Value.RoundString(4) + "℃";

        /// <summary>
        /// EqualsCore
        /// </summary>
        /// <param name="other">比較する値</param>
        /// <returns>同じときtrue</returns>
        protected override bool EqualsCore(MeasureValue other)
        {
            return this.Value == other.Value;
        }
    }
}
