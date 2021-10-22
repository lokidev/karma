using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarmaManagement.Models.Requests;
using KarmaManagement.Services;
using KarmaManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KarmaManagement.Controllers
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

    [HttpPost]
    [Route("logs")]
    public IActionResult GetLogs(LogsRequestModel requestBody)
    {
      var result = _karmaService.GetLogs(requestBody.objectType, requestBody.messageType, requestBody.currDateTime);
      return Ok(result);
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
