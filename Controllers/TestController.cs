using backend_dotnet.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("get-public")]
        public IActionResult GetPublicData()
        {
            return Ok("Public Data");
        }
        [HttpGet]
        [Route("get-user-role")]
        [Authorize(Roles = StaticUserRoles.USER)]
        public IActionResult GetUserData()
        {
            return Ok("User Role Data");
        }

        [HttpGet]
        [Route("get-chief_auditor-role")]
        [Authorize(Roles = StaticUserRoles.CHIEF_AUDITOR)]
        public IActionResult GetChiefAuditorData()
        {
            return Ok("Chief Auditor Role Data");
        }

        [HttpGet]
        [Route("get-auditor-role")]
        [Authorize(Roles = StaticUserRoles.AUDITOR)]
        public IActionResult GetAuditorData()
        {
            return Ok("Chief Auditor Role Data");
        }

        [HttpGet]
        [Route("get-admin-role")]
        [Authorize(Roles = StaticUserRoles.ADMIN)]
        public IActionResult GetAdminData()
        {
            return Ok("Admin Role Data");
        }

        [HttpGet]
        [Route("get-owner-role")]
        [Authorize(Roles = StaticUserRoles.OWNER)]
        public IActionResult GetOwnerData()
        {
            return Ok("Owner Role Data");
        }
    }
}
