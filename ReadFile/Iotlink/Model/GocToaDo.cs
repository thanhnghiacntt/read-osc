using System;
using System.Collections.Generic;
using System.Text;

namespace ReadFile.Iotlink.Model
{
    public class GocToaDo
    {
        public double LatNho { get; set; }
        public double LatLon { get; set; }
        public double LonNho { get; set; }
        public double LonLon { get; set; }

        public GocToaDo()
        {
            LatNho = 360;
            LatLon = -360;
            LonNho = 360;
            LonLon = -360;
        }
    }
}
