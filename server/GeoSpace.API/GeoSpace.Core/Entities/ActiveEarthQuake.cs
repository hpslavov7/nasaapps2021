using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeoSpace.Core.Entities
{
    [Table("ActiveEarthQuakes")]
    public class ActiveEarthQuake
    {
        [Key]
        public Guid Id { get; set; }

        public int EpicentralDistanceKm { get; set; }
        public int Magnitude { get; set; }
        public double Longitude { get; set; }
        public double Lattitude { get; set; }

    }
}
