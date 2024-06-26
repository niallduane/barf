using System.Text.Json.Serialization;

namespace TadaSourceName.Domain.Core;

public class PatchRequest<T> : Dictionary<string, object?> where T : class
{
    [JsonIgnore]
    public T? Model
    {
        get
        {
            var json = Json.Serialize(this);
            return Json.Deserialize<T>(json);
        }
    }
}

