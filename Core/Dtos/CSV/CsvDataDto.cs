using backend_dotnet.Core.Enums;

public class CsvDataDto
{
    public string Standard { get; set; }
    public string MeasureGroup { get; set; }
    public string Measure { get; set; }
    public MinRating MinRating { get; set; }
    public MaxRating MaxRating { get; set; }
}
