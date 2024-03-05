using backend_dotnet.Core.Constants;
using backend_dotnet.Core.Dtos.Log;
using backend_dotnet.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogsController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        [Authorize(Roles = StaticUserRoles.OwnerAdmin)]
        public async Task<ActionResult<IEnumerable<GetLogDto>>> GetLogs()
        {
            var logs = await _logService.GetLogAsync();
            return Ok(logs);
        }

        [HttpGet]
        [Route("private")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GetLogDto>>> GetMyLogs()
        {
            var logs = await _logService.GetMyLogAsync(User);
            return Ok(logs);
        }
    }
}
