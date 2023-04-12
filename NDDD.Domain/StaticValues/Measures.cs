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
    /// <summary>
    /// エリアごとの計測値のリストクラス
    /// </summary>
    public static class Measures
    {
        /// <summary>
        /// エリアごとの直近値のリスト
        /// </summary>
        private static List<MeasureEntity> _entities
            = new List<MeasureEntity>();

        /// <summary>
        /// リストの作成
        /// </summary>
        /// <param name="repository">計測リポジトリ</param>
        public static void Create(IMeasureRepository repository)
        {
            //lockの中の処理している間はほかのところで_entitiesを見に来ても待つ
            lock (((ICollection)_entities).SyncRoot)
            {
                _entities.Clear();
                _entities.AddRange(repository.GetLatests());
            }

        }

        public static void Add(MeasureEntity entity)
        {
            lock (((ICollection)_entities).SyncRoot)
            {
                _entities.Add(entity);
            }

        }

        /// <summary>
        /// 直近値の取得(エリアID指定)。使いたい人用のメソッド。処理中に作り変えられないようにlockする
        /// </summary>
        /// <param name="areaId">エリアID</param>
        /// <returns>直近値</returns>
        public static MeasureEntity GetLatest(AreaId areaId)
        {
            lock (((ICollection)_entities).SyncRoot)
            {
                return _entities.Find(x => x.AreaId == areaId);
            }
        }
    }
}
