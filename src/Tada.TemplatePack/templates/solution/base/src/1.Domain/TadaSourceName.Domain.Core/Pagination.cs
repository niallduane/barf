namespace TadaSourceName.Domain.Core;

public class Pagination
{
    public int Page { get; set; } = 1;
    public int Items { get; set; } = 0;
    public int Pages { get; set; } = 0;
    public int Limit { get; set; } = 50;
    public string? Next { get; set; }
    public string? Previous { get; set; }
}
