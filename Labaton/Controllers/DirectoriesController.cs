using System;
using Labaton.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                var structure = _directoryService.GetDirectoriesStructure(path);
                return Ok(structure);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult CreateStructure([FromForm] string selectedFolder, [FromForm] IFormFile file)
        {
            try
            {
                _applyJsonService.ApplyJson(selectedFolder, file);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}