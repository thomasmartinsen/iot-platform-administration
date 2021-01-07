﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iot_platform_administration.Data.Models.Ui
{
    public class Measurement
    {
        public string Id { get; set; }

        public string CustomerId { get; set; }

        public long Time { get; set; }

        public double Value { get; set; }

        public string DeviceId { get; set; }

        public string MeasurementType { get; set; }
    }
}