using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Infrastructure.SqlServer
{
    /// <summary>
    /// 計測SQLServerクラス
    /// </summary>
    internal sealed class MeasureSqlServer : IMeasureRepository
    {
        /// <summary>
        /// 直近値の取得
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FakeException"></exception>
        public MeasureEntity GetLatest()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// エリアごとの直近値の取得
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<MeasureEntity> GetLatests()
        {
            throw new NotImplementedException();
        }
    }
}
