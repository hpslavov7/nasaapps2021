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

        [HttpGet]
        public IEnumerable<GovernmentReport> Get()
        {

            return GovernmentReport.reports.ToArray();
        }


        [HttpPost]
        public ActionResult Post(GovernmentReport report)
        {
            GovernmentReport.reports.Add(report);
            return StatusCode(201);
        }
    }
}
