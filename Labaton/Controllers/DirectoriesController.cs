using System.Text.Json;
using Labaton.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Labaton.Controllers
{
    [ApiController]
    [Route("api/directories")]
    public class DirectoriesController : ControllerBase
    {
        private readonly IDirectory _directoryService;
        private readonly IApplyJsonService _applyJsonService;

        public DirectoriesController(IApplyJsonService applyJsonService, IDirectory directoryService)
        {
            _directoryService = directoryService;
            _applyJsonService = applyJsonService;
        }

        [HttpGet]
        public ActionResult GetStructure([FromQuery] string path)
        {
            return Ok(_directoryService.GetDirectoriesStructure(path));
        }

        [HttpPost]
        public ActionResult CreateStructure([FromQuery] string selectedFolderPath, JObject structure)
        {
            _applyJsonService.ApplyJson(selectedFolderPath, structure);
            return Ok();
        }
    }
}