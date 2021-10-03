using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Landslide
    {
        public DateTime Date { get; set; }

        public int Latitude { get; set; }

        public int Longitute { get; set; }

        public string Severity { get; set; }

        public string AreaName { get; set; }
    }
}
