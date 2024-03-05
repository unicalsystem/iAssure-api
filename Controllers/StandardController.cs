using AutoMapper;
using backend_dotnet.Core.DbContext;
using backend_dotnet.Core.Dtos.Standard;
using backend_dotnet.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardController : ControllerBase
    {
        private ApplicationDb _context { get; }
        private IMapper _mapper { get; }
        public StandardController(ApplicationDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        //CRUD

        //Create Standard
        [HttpPost]
        [Route("create-standard")]

        public async Task<IActionResult> CreateStandard([FromBody] StandardCreateDto dto) 
            {
             Standard newStandard = _mapper.Map<Standard>(dto);
        await _context.Standards.AddAsync(newStandard);
        await _context.SaveChangesAsync();

            return Ok("Standard Created Successfully");
       }

        [HttpGet]
        [Route("get-standard")]
        public async Task<ActionResult<IEnumerable<StandardGetDto>>> GetStandard()
        {
            var standards = await _context.Standards.OrderByDescending(q => q.CreatedAt).ToListAsync();
            var convertedStandards = _mapper.Map<IEnumerable<StandardGetDto>>(standards);

            return Ok(convertedStandards);
        }

    }
} 
