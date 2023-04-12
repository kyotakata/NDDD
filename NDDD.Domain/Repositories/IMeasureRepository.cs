using NDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.Repositories
{
    public interface IMeasureRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Measureテーブルからとってきたデータを詰め込んで運ぶクラス</returns>
        MeasureEntity GetLatest();

        IReadOnlyList<MeasureEntity> GetLatests();
    }
}
