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
    public class LandslideController : ControllerBase
    {
        private readonly ILogger<LandslideController> _logger;

        public LandslideController(ILogger<LandslideController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Landslide> Get()
        {
            Engine engine = new Engine();
            DbContextOptions<GeoSpaceContext> opt = new DbContextOptions<GeoSpaceContext>();
            using (var db = new GeoSpaceContext(opt))
            {
                var landslides = db.LandSlides.ToArray();
                foreach (var landslide in landslides)
                {
                    LandslideInput input = new LandslideInput
                    {
                        DistanceFromFaults = landslide.DistanceFromFaults,
                        DistanceFromRivers = landslide.DistanceFromRivers,
                        Elevation = landslide.DistanceFromRivers,
                        GeologyPermeability = landslide.GeologyPermeability,
                        LandUse = landslide.LandUse,
                        SlopeAngle = landslide.SlopeAngle,
                        SlopeAspect = landslide.SlopeAspect
                    };
                    GeneralRiskLevel riskLevel = engine.CalculateLSRiskLeve(input,null,null);
                    landslide.GeneralRiskLevel = (int)riskLevel;
                }
                return landslides;
            }
            
        }
    }
}
