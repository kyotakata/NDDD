using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.ValueObjects
{
    /// <summary>
    /// 計測日時
    /// </summary>
    public sealed class MeasureDate : ValueObject<MeasureDate>
    {
        /// <summary>
        /// コンストラクタ。完全コンストラクタパターン。コンストラクタで値設定後は、値を変更できないクラスのこと
        /// </summary>
        /// <param name="value"></param>
        public MeasureDate(DateTime value)
        {
            Value = value;
        }

        /// <summary>
        /// 値。型はデータベースに合わせる。
        /// </summary>
        public DateTime Value { get; }

        /// <summary>
        /// 表示する値
        /// </summary>
        public string DisplayValue => Value.ToString("yyyy/MM/dd HH:mm:ss");

        /// <summary>
        /// EqualsCore
        /// </summary>
        /// <param name="other">比較する値</param>
        /// <returns>同じときtrue</returns>
        protected override bool EqualsCore(MeasureDate other)
        {
            return this.Value == other.Value;
        }
    }
}
