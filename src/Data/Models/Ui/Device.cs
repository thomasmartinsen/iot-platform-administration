using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dpx.IotPlatformAdministration.Data.Models.UI
{
    public class Device
    {
        public string Id { get; set; }
        
        public string CustomerId { get; set; }

        public string DeviceId { get; set; }

        public string DeviceType { get; set; }

        public IEnumerable<int> ForecastTypes { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastUpdated { get; set; }

        public DateTime? LastSeen { get; set; }

        public string VerticalId { get; set; }

        public dynamic Attributes { get; set; }

        public List<string> Tags { get; set; }

        public List<Measurement> Measurements { get; set; }
    }
}
