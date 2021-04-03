using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dpx.Iot.Common.Data;
using Dpx.Iot.Common.Entities;

namespace Dpx.IotPlatformAdministration.Data
{
    public class PointService
    {
        private static IEnumerable<Point> data;
        private readonly IPointRepository pointRepository;

        public PointService(IPointRepository pointRepository)
        {
            this.pointRepository = pointRepository;
        }

        public async Task<List<Point>> GetAsync()
        {
            if (data == null)
            {
                data = await pointRepository.GetAsync();
            }

            return data
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}