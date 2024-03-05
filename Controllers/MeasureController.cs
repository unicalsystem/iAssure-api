using AutoMapper;
using backend_dotnet.Core.DbContext;
using backend_dotnet.Core.Dtos.Measure;
using backend_dotnet.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureController : ControllerBase
    {
        private readonly ApplicationDb _context;
        private readonly IMapper _mapper;

        public MeasureController(ApplicationDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create-measure")]
        public async Task<IActionResult> CreateMeasure([FromForm] MeasureCreateDto dto)
        {
            var newMeasure = _mapper.Map<Measure>(dto);

            // Add other properties mapping if needed

            await _context.Measures.AddAsync(newMeasure);
            await _context.SaveChangesAsync();

            return Ok("Measure Saved Successfully");
        }

        // Read
        [HttpGet]
        [Route("get-measure")]
        public async Task<ActionResult<IEnumerable<MeasureGetDto>>> GetMeasures()
        {
            var measures = await _context.Measures
                .Include(m => m.MeasureGroup)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();

            var convertedMeasures = _mapper.Map<IEnumerable<MeasureGetDto>>(measures);

            return Ok(convertedMeasures);
        }
    }
}
