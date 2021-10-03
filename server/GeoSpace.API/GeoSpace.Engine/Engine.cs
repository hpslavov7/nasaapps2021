using System;
using System.Collections.Generic;
using System.Text;

namespace GeoSpace.Engine
{
    public class Engine
    {
        const double DistanceFromRiversWeight = 0.07 ;
        const double DistanceFromFaultsWeight = 0.05;
        const double ElevationWeight = 0.11;
        const double GeologyPermeabilityWeight = 0.24;
        const double LandUseWeight = 0.03;
        const double SlopeAngleWeight = 0.35;
        const double SlopeAspectWeight = 0.16;

        public GeneralRiskLevel CalculateLSRiskLeve(LandslideInput staticInput,EarthQuakeInput earthQuakeInput=null,PrecipitationRateInput precipitationInput=null)
        {
            if (GetPrecipiationLevel(precipitationInput))return GeneralRiskLevel.VeryHigh;
            if (GetEartQuakeLevel(earthQuakeInput)) return GeneralRiskLevel.VeryHigh;
            return GetClassicLevel(staticInput);
        }

        private bool GetPrecipiationLevel(PrecipitationRateInput precipitationInput)
        {
            
                return precipitationInput != null?precipitationInput.Hours < 24? precipitationInput.Rate > 15.58 * Math.Pow(precipitationInput.Hours, -0.52): precipitationInput.Rate >13.35* Math.Pow(precipitationInput.Hours, -0.44):false;
 
        }

        private bool GetEartQuakeLevel(EarthQuakeInput input)
        {
            if(input != null)
            {
                return input.EpicentralDistanceKm < 10&& input.Magnitude >= 4;
            }
            return false;
        }

        private GeneralRiskLevel GetClassicLevel(LandslideInput input)
        {

            double riskRate = GetDistanceFromRate(input.DistanceFromRivers) * DistanceFromRiversWeight + GetDistanceFromRate(input.DistanceFromFaults) * DistanceFromFaultsWeight +
                GetElevationRate(input.Elevation) * ElevationWeight + (int)input.GeologyPermeability * GeologyPermeabilityWeight + GetLandUseRate(input.LandUse) * LandUseWeight +GetSlopeAngleRate(input.SlopeAngle) *SlopeAngleWeight
                + GetSlopeAspectRate(input.SlopeAspect) * SlopeAspectWeight;
            return GetClassicRiskValue(riskRate);

        }

        private GeneralRiskLevel GetClassicRiskValue(double riskRate)
        {
            if ( riskRate <= 1.0) return GeneralRiskLevel.VerLow;
            if (1.0 < riskRate && riskRate <= 2.0) return GeneralRiskLevel.Low;
            if (5.0 < riskRate && riskRate <= 15.0) return GeneralRiskLevel.Moderate;
            if (15.0 < riskRate && riskRate <= 35.0) return GeneralRiskLevel.High;
            if (35.0 < riskRate) return GeneralRiskLevel.VeryHigh;
            else return GeneralRiskLevel.VeryHigh;
        }
        private int GetSlopeAngleRate(float riskRate)
        {
            if (0.0 <= riskRate && riskRate <= 2.0) return 1;
            if (2.0 < riskRate && riskRate <= 5.0) return 2;
            if (5.0 < riskRate && riskRate <= 15.0) return 3;
            if (15.0 < riskRate && riskRate <= 35.0) return 4;
            if (35.0 < riskRate) return 5;
            else return 1;
        }

        private int GetElevationRate(int meters)
        {
            if ( meters < 500) return 1;
            if (500 < meters && meters <= 600) return 2;
            if (600< meters && meters <= 700) return 3;
            if (700 < meters && meters <= 800) return 4;
            if (800 < meters) return 5;
            else return 1;
        }

        private int GetDistanceFromRate(int meters)
        {
            if ( meters <=100) return 1;
            if (100 < meters && meters <= 200) return 2;
            if (200 < meters && meters <= 300) return 3;
            if (300 < meters && meters <= 400) return 4;
            if (400 < meters) return 5;
            else return 1;
        }

        private int GetLandUseRate(LandUse rate)
        {
            int result = 1;
            switch (rate)
            {
                case LandUse.Arableland:
                    result = 5;
                    break;
                case LandUse.BareRock:
                    result = 2;
                    break;
                case LandUse.Forest:
                    result = 3;
                    break;
                case LandUse.Grassland:
                    result = 4;
                    break;
                case LandUse.UrbanAreas:
                    result = 2;
                    break;
                case LandUse.WaterAreas:
                    result = 1;
                    break;
                default:
                    break;
            }
            return result;
        }

        private int GetSlopeAspectRate(SlopeAspect rate)
        {
            int result = 1;
            switch (rate)
            {
                case SlopeAspect.East:
                    result = 4;
                    break;
                case SlopeAspect.Flat:
                    result = 1;
                    break;
                case SlopeAspect.NortEast:
                    result = 3;
                    break;
                case SlopeAspect.North:
                    result = 2;
                    break;
                case SlopeAspect.NorthWest:
                    result = 3;
                    break;
                case SlopeAspect.South:
                    result = 5;
                    break;
                case SlopeAspect.SouthEast:
                    result = 5;
                    break;
                case SlopeAspect.SouthWest:
                    result = 4;
                    break;
                case SlopeAspect.West:
                    result = 3;
                    break;
                default:
                    break;
            }
            return result;
        }




        public class ClassicLevelRatesHolder
        {
            public int riskRate { get; set; }
            public int GeologyPermeability { get; set; }
            public int SlopeAspect { get; set; }
            public int Elevation { get; set; }
            public int DistanceFromRivers { get; set; }
            public int LandUse { get; set; }
            public int DistanceFromFaults { get; set; }
        }
    }
}
