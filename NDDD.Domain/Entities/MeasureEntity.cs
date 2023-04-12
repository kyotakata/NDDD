using NDDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.Entities
{
    public sealed class MeasureEntity
    {
        /// <summary>
        /// 計測エンティティ。完全コンストラクタパターン(コンストラクタで指定しないとnewできないようにする)
        /// </summary>
        /// <param name="areaId">エリアID</param>
        /// <param name="measureDate">測定日時</param>
        /// <param name="measureValue">測定値</param>
        public MeasureEntity(
            int areaId,
            DateTime measureDate,
            float measureValue)
        {
            AreaId = new AreaId(areaId);
            MeasureDate = new MeasureDate(measureDate);
            MeasureValue = new MeasureValue(measureValue);
        }

        // Measureテーブルからとってこれるであろうデータを持たせる
        /// <summary>
        /// エリアID
        /// </summary>
        public AreaId AreaId { get; }

        /// <summary>
        /// 計測日時
        /// </summary>
        public MeasureDate MeasureDate { get; }

        /// <summary>
        /// 計測値
        /// </summary>
        public MeasureValue MeasureValue { get; }
    }
}
