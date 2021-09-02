using Labaton.DTOs;
using Labaton.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Labaton.Controllers
{
    [ApiController]
    [Route("directories")]
    public class DirectoriesController : ControllerBase
    {
        private readonly IDirectory _directoryService;
        
        public DirectoriesController(IDirectory directoryService)
        {
            _directoryService = directoryService;
        }
        

        [HttpGet("getStructure")]
        public ActionResult GetStructure(GetStructureDto getStructureDto)
        { 
            return Ok(_directoryService.GetDirectoriesStructure(getStructureDto));
        }
        
        
        //One POST method for getting json and applying it  
    }
}