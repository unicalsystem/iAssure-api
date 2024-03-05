using System.ComponentModel.DataAnnotations;

namespace backend_dotnet.Core.Entities
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set;} = DateTime.Now;
        public bool IsActive { get; set; } = true;

    }
}
