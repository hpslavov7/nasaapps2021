using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
            var rng = new Random();
            return Enumerable.Range(1, 120).Select(index =>
            {
                
                return new Landslide
                {
                    Date = DateTime.Now.AddDays(index),
                    Latitude = rng.Next(-85, 85),
                    Longitute = rng.Next(-175, 170),
                    Severity = LandslideSeverity.High.ToString(),
                    AreaName = "Landslide Area"
            };
            })
            .ToList();
        }
    }
}
