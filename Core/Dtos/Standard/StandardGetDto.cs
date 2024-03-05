namespace backend_dotnet.Core.Dtos.Standard
{
    public class StandardGetDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
