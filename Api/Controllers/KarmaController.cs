using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarmaApi.Services;
using KarmaApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KarmaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KarmaController : ControllerBase
    {
        private IKarmaService _karmaService;
        public KarmaController(IKarmaService karmaService)
        {
            _karmaService = karmaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_karmaService.GetAll());
        }

        [HttpGet]
        [Route("clock/start")]
        public IActionResult StartWorldClock()
        {
            _karmaService.StartClock();
            return Ok("World Started");
        }

        [HttpGet]
        [Route("clock/stop")]
        public IActionResult StopWorldClock()
        {
            _karmaService.StopClock();
            return Ok("World Stopped");
        }
    }
}
