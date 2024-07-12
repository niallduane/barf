using System.Text.Json.Serialization;

using TadaSourceName.Domain.Core.Extensions;

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
    public Dictionary<string, object?> MapToObjectProperties<E>() where E : class
    {
        return Extensions.DictionaryExtensions.MapToObjectProperties<E>(this);
    }
}

