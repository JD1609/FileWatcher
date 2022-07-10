using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SourceWatcher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileTrackerController : ControllerBase
    {
        private readonly IFileTrackerService _fileTrackerService;

        public FileTrackerController(IFileTrackerService fileTrackerService)
        {
            _fileTrackerService = fileTrackerService;
        }


        [HttpPost("set-path")]
        public ActionResult<RequestResponse<string>> SetPath([FromBody] string path)
        {
            var response = _fileTrackerService.SetPath(path);

            return Ok(response);
        }


        [HttpPost("get-changes")]
        public ActionResult<RequestResponse<List<ChangeData>>> GetChanges([FromBody] DateTime? getFrom)
        {
            var response = _fileTrackerService.GetChanges(getFrom);

            return Ok(response);
        }
    }
}
