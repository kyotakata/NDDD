using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using NDDD.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.StaticValues
{
    public static class Measures
    {
        private static List<MeasureEntity> _entities
            = new List<MeasureEntity>();

        public static void Create(IMeasureRepository repository)
        {
            //lockの中の処理している間はほかのところで_entitiesを見に来ても待つ
            lock (((ICollection)_entities).SyncRoot)
            {
                _entities.Clear();
                _entities.AddRange(repository.GetLatests());
            }

        }

        /// <summary>
        /// 使いたい人用のメソッド。処理中に作り変えられないようにlockする
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public static MeasureEntity GetLatest(AreaId areaId)
        {
            lock (((ICollection)_entities).SyncRoot)
            {
                return _entities.Find(x => x.AreaId == areaId);
            }
        }
    }
}
