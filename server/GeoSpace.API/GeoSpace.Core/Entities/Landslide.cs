using GeoSpace.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeoSpace.Core.Entities
{
    [Table("Landslides")]

    public class Landslide
    {
        [Key]
        public Guid Id { get; set; }
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
        public int GeneralRiskLevel { get; set; }
        public float SlopeAngle { get; set; }
        public GeneralRiskLevel GeologyPermeability { get; set; }
        public SlopeAspect SlopeAspect { get; set; }
        public int Elevation { get; set; }
        public int DistanceFromRivers { get; set; }
        public int DistanceFromFaults { get; set; }
        public LandUse LandUse { get; set; }
    }
}
