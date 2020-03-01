using System.Threading.Tasks;
using MVCApplicationSample.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace VMS.Controllers
{

  [Route("api/namedata")]
  [ApiController]
  public class NameDataController : Controller
  {
    private readonly INameDataService nameDataService;

    public NameDataController(INameDataService nameDataService)
    {
      this.nameDataService = nameDataService;
    }
    [HttpPost]
    [Route("")]
    public async Task<IActionResult>  CreateNameData([FromBody] NameDataModel model)
    {
       var result=await nameDataService.CreateName(model);

      return Ok(result);
    }
  }
}