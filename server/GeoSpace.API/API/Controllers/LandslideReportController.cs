using API.Entities;
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
    public class LandslideReportController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<LandslideReportController> _logger;

        public LandslideReportController(ILogger<LandslideReportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<LandslideReport> Get()
        {
           
            return LandslideReport.reports.ToArray();
        }

        [HttpPost]
        public ActionResult Post(LandslideReport report)
        {
            LandslideReport.reports.Add(report);
            return StatusCode(201);
        }
    }
}
