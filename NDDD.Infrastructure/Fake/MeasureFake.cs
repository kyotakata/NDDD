using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Infrastructure.Fake
{
    public class MeasureFake : IMeasureRepository
    {
        public MeasureEntity GetLatest()
        {
            return new MeasureEntity(
                10,
                Convert.ToDateTime("2020/12/12 12:34:56"),
                123.341f);
        }
    }
}
