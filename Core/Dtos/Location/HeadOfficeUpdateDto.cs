using backend_dotnet.Core.Enums;

namespace backend_dotnet.Core.Dtos.Location
{
    public class HeadOfficeUpdateDto
    {
        public string Location { get; set; }
        public string StreetName { get; set; }
        public string LandMark { get; set; }
        public States State { get; set; }
        public Districts District { get; set; }
        public int Pincode { get; set; }

    }
}
