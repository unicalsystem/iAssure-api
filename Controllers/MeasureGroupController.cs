using AutoMapper;
using backend_dotnet.Core.DbContext;
using backend_dotnet.Core.Dtos.MeasureGroup;
using backend_dotnet.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureGroupController : ControllerBase
    {
        private ApplicationDb _context { get; }
        private IMapper _mapper { get; }
        public MeasureGroupController(ApplicationDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // Create
        [HttpPost]
        [Route("create-measuregroup")]
        public async Task<IActionResult> CreateMeasureGroup([FromBody] MeasureGroupCreateDto dto)
        {
            var newMeasureGroup = _mapper.Map<MeasureGroup>(dto);
            await _context.MeasureGroups.AddAsync(newMeasureGroup);
            await _context.SaveChangesAsync();

            return Ok("MeasureGroup Created Successfully");
        }

        // Get
        [HttpGet]
        [Route("get-measuregroup")]
        public async Task<ActionResult<IEnumerable<MeasureGroupGetDto>>> GetMeasureGroup()
        {
            var measuregroups = await _context.MeasureGroups.Include(measuregroups => measuregroups.Standard).OrderByDescending(q => q.CreatedAt).ToListAsync();
            var convertdmeasuregroups = _mapper.Map<IEnumerable<MeasureGroupGetDto>>(measuregroups);

            return Ok(convertdmeasuregroups);
        }
    }
}
