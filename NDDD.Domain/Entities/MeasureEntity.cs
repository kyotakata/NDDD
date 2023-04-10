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
        /// 完全コンストラクタパターン(コンストラクタで指定しないとnewできないようにする)
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="measureDate"></param>
        /// <param name="measureValue"></param>
        public MeasureEntity(
            int areaId,
            DateTime measureDate,
            float measureValue)
        {
            AreaId = new AreaId(areaId);
            MeasureDate = new MeasureDate(measureDate);
            MeasureValue = measureValue;
        }

        // Measureテーブルからとってこれるであろうデータを持たせる
        public AreaId AreaId { get; }
        public MeasureDate MeasureDate { get; }
        public float MeasureValue { get; }
    }
}
