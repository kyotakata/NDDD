using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.ValueObjects
{
    /// <summary>
    /// エリアID
    /// </summary>
    public sealed class AreaId: ValueObject<AreaId>
    {
        /// <summary>
        /// コンストラクタ完全コンストラクタパターン。コンストラクタで値設定後は、値を変更できないクラスのこと
        /// </summary>
        /// <param name="value"></param>
        public AreaId(int value)
        {
            Value = value;
        }

        /// <summary>
        /// 値。型はデータベースに合わせる。
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// 表示する値
        /// </summary>
        public string DisplayValue => Value.ToString().PadLeft(4, '0');

        /// <summary>
        /// EcoalCore
        /// </summary>
        /// <param name="other">比較する値</param>
        /// <returns>同じときtrue</returns>
        protected override bool EqualsCore(AreaId other)
        {
            return this.Value == other.Value;
        }
    }
}
