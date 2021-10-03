using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeoSpace.Core.Entities
{
    [Table("ActiveRainFalls")]
    public class ActiveRainFall
    {
        [Key]
        public Guid Id { get; set; }

        public double Rate { get; set; }
        public double Hours { get; set; }
        public double Longitude { get; set; }
        public double Lattitude { get; set; }

    }
}
