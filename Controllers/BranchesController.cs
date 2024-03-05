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
    public class BranchesController : ControllerBase
    {
        private readonly ApplicationDb _context;
        private readonly IMapper _mapper;

        public BranchesController(ApplicationDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create Branch
        [HttpPost]
        [Route("create-branch")]
        public async Task<ActionResult<BranchGetDto>> PostBranch(BranchCreateDto branchDto)
        {
            try
            {
                // Map BranchCreateDto to Branch entity
                var branch = _mapper.Map<Branch>(branchDto);

                // Find the associated HeadOffice by its id
                var headOffice = await _context.HeadOffice.FindAsync(branchDto.HeadOfficeId);
                if (headOffice == null)
                {
                    return BadRequest("Invalid HeadOfficeId. Head Office not found.");
                }

                // Associate the branch with the found HeadOffice
                branch.HeadOffice = headOffice;

                // Add the branch to the context and save changes
                _context.Branch.Add(branch);
                await _context.SaveChangesAsync();

                return Ok("Branch created Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }




        // Get All Branches
        [HttpGet]
        [Route("get-allbranches")]
        public async Task<ActionResult<IEnumerable<BranchGetDto>>> GetBranches()
        {
            var branches = await _context.Branch.ToListAsync();
            var branchDtos = _mapper.Map<IEnumerable<BranchGetDto>>(branches);
            return Ok(branchDtos);
        }

        // Get Branches by Id
        [HttpGet]
        [Route("get-branches/{id}")]
        public async Task<ActionResult<BranchGetDto>> GetBranch(int id)
        {
            var branch = await _context.Branch.FindAsync(id);

            if (branch == null)
            {
                return NotFound();
            }

            var branchDto = _mapper.Map<BranchGetDto>(branch);
            return Ok(branchDto);
        }

        // Update Branch
        [HttpPut]
        [Route("update-branch/{id}")]
        public async Task<IActionResult> UpdateBranch(int id, BranchUpdateDto branchDto)
        {
            var branch = await _context.Branch.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            _mapper.Map(branchDto, branch);

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Branch updated successfully.");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        private bool BranchExists(int id)
        {
            return _context.Branch.Any(e => e.Id == id);
        }
    }
}
