using backend_dotnet.Core.Enums;

namespace backend_dotnet.Core.Entities
{
    public class Measure : Base
    {
        public string Name { get; set; }
        public MinRating MinRating { get; set; }
        public MaxRating MaxRating { get; set; }

        //Relations

        public int MeasureGroupId { get; set; }
        public MeasureGroup MeasureGroup { get; set; }
    }
}
