using NDDD.Domain.Entities;
using NDDD.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.Repositories
{
    /// <summary>
    /// Repositoryの具象クラス
    /// </summary>
    public sealed class MeasureRepository
    {
        private IMeasureRepository _measureRepository;

        public MeasureRepository(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
        }

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
