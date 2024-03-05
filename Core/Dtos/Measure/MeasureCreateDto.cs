using backend_dotnet.Core.Enums;

namespace backend_dotnet.Core.Dtos.Measure
{
    public class MeasureCreateDto
    {
        public string Name { get; set; }
        public MinRating MinRating { get; set; }
        public MaxRating MaxRating { get; set; }

        public int MeasureGroupId { get; set; }
    }
}
