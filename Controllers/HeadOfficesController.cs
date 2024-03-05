using AutoMapper;
using backend_dotnet.Core.DbContext;
using backend_dotnet.Core.Dtos.Location;
using backend_dotnet.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadOfficesController : ControllerBase
    {
        private readonly ApplicationDb _context;
        private readonly IMapper _mapper;

        public HeadOfficesController(ApplicationDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create HeadOffice
        [HttpPost]
        [Route("create-headoffice")]
        public async Task<ActionResult<HeadOfficeGetDto>> PostHeadOffice(HeadOfficeCreateDto headOfficeDto)
        {
            var headOffice = _mapper.Map<HeadOffice>(headOfficeDto);
            _context.HeadOffice.Add(headOffice);
            await _context.SaveChangesAsync();

            return Ok("Head Office is created Sucessfully");
        }

        // Get All HeadOffices
        [HttpGet]
        [Route("get-headoffices")]
        public async Task<ActionResult<IEnumerable<HeadOfficeGetDto>>> GetHeadOffices()
        {
            var headOffices = await _context.HeadOffice.ToListAsync();
            var headOfficeDtos = _mapper.Map<IEnumerable<HeadOfficeGetDto>>(headOffices);
            return Ok(headOfficeDtos);
        }

        // Get HeadOffice by Id
        [HttpGet]
        [Route("get-headoffice/{id}")]
        public async Task<ActionResult<HeadOfficeGetDto>> GetHeadOffice(int id)
        {
            var headOffice = await _context.HeadOffice.FindAsync(id);

            if (headOffice == null)
            {
                return Ok("User does not exist");
            }

            var headOfficeDto = _mapper.Map<HeadOfficeGetDto>(headOffice);
            return Ok(headOfficeDto);
        }

        // Update HeadOffice
        [HttpPut]
        [Route("update-headoffice/{id}")]
        public async Task<IActionResult> UpdateHeadOffice(int id, HeadOfficeUpdateDto headOfficeDto)
        {
            var headOffice = await _context.HeadOffice.FindAsync(id);
            if (headOffice == null)
            {
                return NotFound();
            }

            _mapper.Map(headOfficeDto, headOffice);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return Ok("Head Office updated successfully");
        }


    }
}
