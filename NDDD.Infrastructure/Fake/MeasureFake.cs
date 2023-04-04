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
            throw new NotImplementedException();
        }
    }
}
