using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class LandslideReport
    {
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string NearbyCity { get; set; }
        public string ReporterName { get; set; }
        public int ReporterContact { get; set; }

        public static List<LandslideReport> reports = new List<LandslideReport>();

    }
}
