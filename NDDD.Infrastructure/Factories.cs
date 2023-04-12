using NDDD.Domain;
using NDDD.Domain.Repositories;
using NDDD.Infrastructure.Fake;
using NDDD.Infrastructure.SqlServer;

namespace NDDD.Infrastructure
{
    /// <summary>
    /// ファクトリー
    /// </summary>
    public static class Factories
    {
        /// <summary>
        /// 計測リポジトリーの作成
        /// </summary>
        /// <returns>計測リポジトリー</returns>
        public static IMeasureRepository CreateMeasure()
        {
#if DEBUG
            if (Shared.IsFake)
            {
                return new MeasureFake();
            }
#endif

            return new MeasureSqlServer();
        }
    }
}
