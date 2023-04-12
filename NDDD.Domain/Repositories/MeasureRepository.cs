using NDDD.Domain.Entities;
using NDDD.Domain.Exceptions;

namespace NDDD.Domain.Repositories
{
    /// <summary>
    /// 計測リポジトリー。Repositoryの具象クラス
    /// </summary>
    public sealed class MeasureRepository
    {
        /// <summary>
        /// 計測リポシトリー
        /// </summary>
        private IMeasureRepository _measureRepository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="measureRepository"></param>
        public MeasureRepository(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
        }

        /// <summary>
        /// 直近値の取得
        /// 3回計測した平均を返却する
        /// </summary>
        /// <returns>直近値</returns>
        /// <exception cref="DataNotExixtsException"></exception>
        public MeasureEntity GetLatest()
        {
            var val1 = _measureRepository.GetLatest();
            if (val1 == null)
            {
                throw new DataNotExixtsException();
            }
            System.Threading.Thread.Sleep(1000);
            var val2 = _measureRepository.GetLatest();
            System.Threading.Thread.Sleep(1000);
            var val3 = _measureRepository.GetLatest();
            System.Threading.Thread.Sleep(1000);

            var sum = val1.MeasureValue.Value + 
                      val2.MeasureValue.Value + 
                      val3.MeasureValue.Value;

            var ave = sum / 3f;

            return new MeasureEntity(val3.AreaId.Value, val3.MeasureDate.Value, ave);
        }
    }
}
