using System.Threading.Tasks;
using MVCApplicationSample.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace VMS.Controllers
{

  [Route("api/vehiclemanagement")]
  [ApiController]
  public class NameDataController : Controller
  {
    private readonly INameDataService nameDataService;

    public NameDataController(INameDataService nameDataService)
    {
      this.INameDataService = nameDataService;
    }
    [HttpPost]
    [Route("")]
    public IActionResult CreateVehicle([FromBody] NameModel model)
    {
      var namecollection = nameDataService.CreateName(model);

      return Ok(new { namecollection.Id });
    }
  }
}