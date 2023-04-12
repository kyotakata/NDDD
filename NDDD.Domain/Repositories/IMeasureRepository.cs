using NDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.Repositories
{
    /// <summary>
    /// 計測リポジトリー
    /// </summary>
    public interface IMeasureRepository
    {
        /// <summary>
        /// 直近値の取得
        /// </summary>
        /// <returns>Measureテーブルからとってきたデータを詰め込んで運ぶクラス</returns>
        MeasureEntity GetLatest();

        /// <summary>
        /// エリアごとの直近値を取得
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<MeasureEntity> GetLatests();
    }
}
