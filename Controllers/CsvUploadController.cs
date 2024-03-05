using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_dotnet.Core.DbContext;
using backend_dotnet.Core.Entities;
using backend_dotnet.Core.Dtos.Measure;
using backend_dotnet.Core.Dtos.MeasureGroup;
using backend_dotnet.Core.Dtos.Standard;
using CsvHelper.Configuration;

namespace backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvUploadController : ControllerBase
    {
        private readonly ApplicationDb _context;

        public CsvUploadController(ApplicationDb context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("upload-csv")]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<CsvDataDto>();
                foreach (var record in records)
                {
                    // Check for duplicates
                    var existingStandard = await _context.Standards.FirstOrDefaultAsync(s => s.Name == record.Standard);
                    if (existingStandard == null)
                    {
                        // Create new Standard
                        var newStandard = new Standard { Name = record.Standard };
                        _context.Standards.Add(newStandard);
                        await _context.SaveChangesAsync();
                        existingStandard = newStandard;
                    }

                    // Check for duplicates
                    var existingMeasureGroup = await _context.MeasureGroups.FirstOrDefaultAsync(mg => mg.MeasureName == record.MeasureGroup && mg.StandardId == existingStandard.Id);
                    if (existingMeasureGroup == null)
                    {
                        // Create new MeasureGroup
                        var newMeasureGroup = new MeasureGroup { MeasureName = record.MeasureGroup, StandardId = existingStandard.Id };
                        _context.MeasureGroups.Add(newMeasureGroup);
                        await _context.SaveChangesAsync();
                        existingMeasureGroup = newMeasureGroup;
                    }

                    // Check for duplicates
                    var existingMeasure = await _context.Measures.FirstOrDefaultAsync(m => m.Name == record.Measure && m.MeasureGroupId == existingMeasureGroup.Id);
                    if (existingMeasure == null)
                    {
                        // Create new Measure
                        var newMeasure = new Measure { Name = record.Measure, MinRating = record.MinRating, MaxRating = record.MaxRating, MeasureGroupId = existingMeasureGroup.Id };
                        _context.Measures.Add(newMeasure);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return Ok("CSV data uploaded successfully.");
        }

    }
}
