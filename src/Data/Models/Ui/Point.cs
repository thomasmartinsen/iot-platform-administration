using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iot_platform_administration.Data.Models.Ui
{
    public class Point
    {
        public Point()
        {
            CustomerId = string.Empty;
            VerticalId = string.Empty;
            Name = string.Empty;
            Devices = new List<Device>();
            Tags = new List<string>();
        }

        public string Id { get; set; }

        public string CustomerId { get; set; }

        public string VerticalId { get; set; }

        public dynamic? Attributes { get; set; }

        public string Name { get; set; }

        public List<string> Tags { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public List<Device> Devices { get; set; }
    }
}
