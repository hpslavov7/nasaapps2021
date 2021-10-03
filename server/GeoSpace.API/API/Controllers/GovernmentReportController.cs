using API.Entities;
using GeoSpace.Core.Entities;
using GeoSpace.Engine;
using GeoSpace.Infrastructure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GovernmentReportController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GovernmentReportController> _logger;

        public GovernmentReportController(ILogger<GovernmentReportController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<GovernmentReport> Get()
        //{

        //    return GovernmentReport.reports.ToArray();
        //}


        [HttpPost]
        public ActionResult Post(GovernmentReport report)
        {
            // insert
            Engine engine = new Engine();
            DbContextOptions<GeoSpaceContext> opt = new DbContextOptions<GeoSpaceContext>();
            GeoSpaceContext geoSpaceContext = new GeoSpaceContext(opt);
            using (var db = new GeoSpaceContext(opt))
            {
                var landslides = db.Set<Landslide>();
                LandslideInput input = new LandslideInput
                {
                    DistanceFromFaults = report.DistanceFromFaults,
                    DistanceFromRivers = report.DistanceFromRivers,
                    Elevation = report.Elevation,
                    GeologyPermeability = report.GeologyPermeability,
                    LandUse = report.LandUse,
                    SlopeAngle = report.SlopeAngle,
                    SlopeAspect = report.SlopeAspect
                };

                Landslide landslide = new Landslide
                {
                    Address = report.Address,
                    Casualities = report.Casualities,
                    Damages = report.Damages,
                    Date = report.Date,
                    Depth = report.Depth,
                    GovernmentId = report.GovernmentId,
                    LandslideForcesDetails = report.LandslideForcesDetails,
                    LandslideMaterialType = report.LandslideMaterialType,
                    LandslideMovementType = report.LandslideMovementType,
                    LatitudeCenter = report.LatitudeCenter,
                    LongitudeCenter = report.LongitudeCenter,
                    Length = report.Length,
                    LinearMovement = report.LinearMovement,
                    RainfallCorrelation = report.RainfallCorrelation,
                    ReportedBy = report.ReportedBy,
                    SlopeSteepness = report.SlopeSteepness,
                    Volume = report.Volume,
                    Width = report.Width
                };
               GeneralRiskLevel risklevel = engine.CalculateLSRiskLeve(input, null, null);
                landslide.GeneralRiskLevel = ((int)risklevel);
                landslides.Add(landslide);

                db.SaveChanges();
            }
            return StatusCode(201);
        }
    }
}
