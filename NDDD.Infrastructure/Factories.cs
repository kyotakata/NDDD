using NDDD.Domain;
using NDDD.Domain.Repositories;
using NDDD.Infrastructure.Fake;
using NDDD.Infrastructure.SqlServer;

namespace NDDD.Infrastructure
{
    public static class Factories
    {
        public static IMeasureRepository CreateMeasure()
        {
            if (Shared.IsFake)
            {
                return new MeasureFake();
            }

            return new MeasureSqlServer();
        }
    }
}
