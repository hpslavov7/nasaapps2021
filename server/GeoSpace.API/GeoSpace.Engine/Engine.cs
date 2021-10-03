using System;
using System.Collections.Generic;
using System.Text;

namespace GeoSpace.Engine
{
    public class Engine
    {
        public MaximumSusceptibilityType CalculateLSRiskLeve(LandslideInput staticInput,EarthQuakeInput earthQuakeInput=null,PrecipitationRateInput precipitationInput=null)
        {
            if (GetPrecipiationLevel(precipitationInput))return MaximumSusceptibilityType.Rain;
            if (GetEartQuakeLevel(earthQuakeInput)) return MaximumSusceptibilityType.Earquake;
            if
        }

        private bool GetPrecipiationLevel(PrecipitationRateInput precipitationInput)
        {
            
                return precipitationInput != null?precipitationInput.Hours < 24? precipitationInput.Rate > 15.58 * Math.Pow(precipitationInput.Hours, -0.52): precipitationInput.Rate >13.35* Math.Pow(precipitationInput.Hours, -0.44):false;
 
        }

        private bool GetEartQuakeLevel(EarthQuakeInput input)
        {
            return input.EpicentralDistanceKm < 10&& input.Magnitude >= 4;
        }

        private bool GetClassicLevel(LandslideInput input)
        {
            var holder = new ClassicLevelRatesHolder();
            if(input.SlopeAngle)
            return input.EpicentralDistanceKm < 10 && input.Magnitude >= 4;
        }

        private int GetSlopeAngleRate(float slopeAngle)
        {
            int result = 1;
            if()
            switch (expression)
            {
                case x:
                    // code block
                    break;
                case y:
                    // code block
                    break;
                default:
                    // code block
                    break;
            }
        }
        public class ClassicLevelRatesHolder
        {
            public int SlopeAngle { get; set; }
            public int GeologyPermeability { get; set; }
            public int SlopeAspect { get; set; }
            public int Elevation { get; set; }
            public int DistanceFromRivers { get; set; }
            public int LandUse { get; set; }
        }
    }
}
