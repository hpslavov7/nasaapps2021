using System;

namespace GeoSpace.Engine
{
    public class LandslideInput
    {
        public float SlopeAngle { get; set; }
        public GeneralRiskLevel GeologyPermeability { get; set; }
        public SlopeAspect SlopeAspect { get; set; }
        public int Elevation { get; set; }
        public int DistanceFromRivers { get; set; }
        public int DistanceFromFaults { get; set; }
        public LandUse LandUse { get; set; }
    }
}
