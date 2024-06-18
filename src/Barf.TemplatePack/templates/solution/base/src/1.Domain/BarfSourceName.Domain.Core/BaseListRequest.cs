
namespace BarfSourceName.Domain.Core;

public class BaseListRequest
{
    public int Limit { get; set; } = 50;
    public int Page { get; set; } = 1;
    public string? Sort { get; set; }
    public string? Q { get; set; }
    public string? Expand { get; set; }
}
