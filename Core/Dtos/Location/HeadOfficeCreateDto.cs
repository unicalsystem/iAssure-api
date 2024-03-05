using backend_dotnet.Core.Enums;

namespace backend_dotnet.Core.Dtos.Location
{
    public class HeadOfficeCreateDto
    {
        public string Location { get; set; }
        public int HeadOfficeNumber { get; set; }
        public string StreetName { get; set; }
        public string LandMark { get; set; }
        public States State { get; set; }
        public Districts District { get; set; }
        public int Pincode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
    }
}
