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
        private readonly IDirectoryService _directoryServiceService;
        private readonly IApplyJsonService _applyJsonService;

        public DirectoriesController(IApplyJsonService applyJsonService, IDirectoryService directoryServiceService)
        {
            _directoryServiceService = directoryServiceService;
            _applyJsonService = applyJsonService;
        }

        [HttpGet]
        public ActionResult GetStructure([FromQuery] string path)
        {
            try
            {
                var structure = _directoryServiceService.GetDirectoriesStructure(path);
                return Ok(structure);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult CreateStructure([FromForm] string selectedFolder, [FromForm]bool isOverwrite, [FromForm] IFormFile file)
        {
            try
            {
                _applyJsonService.ApplyJson(selectedFolder, file, isOverwrite);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}