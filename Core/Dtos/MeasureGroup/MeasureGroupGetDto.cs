namespace backend_dotnet.Core.Dtos.MeasureGroup
{
    public class MeasureGroupGetDto
    {
        public long ID { get; set; }
        public string MeasureName { get; set; }
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
