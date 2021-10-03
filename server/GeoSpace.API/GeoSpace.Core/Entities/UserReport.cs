using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeoSpace.Core.Entities
{
    [Table("UserReport")]

        public class UserReport
    {
            [Key]
            public Guid Id { get; set; }
            public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string NearbyCity { get; set; }
        public string ReporterName { get; set; }
        public int ReporterContact { get; set; }
    }
}
