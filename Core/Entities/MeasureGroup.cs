namespace backend_dotnet.Core.Entities
{
    public class MeasureGroup :Base
    {
        public string MeasureName { get; set; }

        //Relations

        public int StandardId { get; set; }
        public Standard Standard { get; set; }

        public ICollection<Measure> Measures { get; set; }
    }
}
