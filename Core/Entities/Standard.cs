namespace backend_dotnet.Core.Entities
{
    public class Standard  : Base
    {
        public string Name { get; set; }

        //Relations
        public ICollection<MeasureGroup> MeasureGroups { get; set; }
    }
}
