﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class GovernmentReport
    {
        public string LandslideMovementType { get; set; }
        public string LandslideMaterialType { get; set; }
        public string RainfallCorrelation { get; set; }
        public string LandslideForcesDetails { get; set; }
        public decimal LatitudeCenter { get; set; }
        public decimal LongitudeCenter { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal Depth { get; set; }
        public decimal SlopeSteepness { get; set; }
        public decimal LinearMovement { get; set; }
        public decimal Volume { get; set; }
        public string GovernmentId { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string ReportedBy { get; set; }
        public string Damages { get; set; }
        public string Casualities { get; set; }

    }
}