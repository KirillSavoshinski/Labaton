using Labaton.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Labaton.Controllers
{
    [ApiController]
    public class DirectoriesController : ControllerBase
    {
        private readonly IDirectory _directoryService;
        
        public DirectoriesController(IDirectory directoryService)
        {
            _directoryService = directoryService;
        }
        
        //One GET method for sending all folders
        [HttpGet("getStructure")]
        public ActionResult GetStructure()
        {
            _directoryService.GetDirectoriesStructure();
            return Ok();
        }
        //One POST method for getting json and applying it  
    }
}