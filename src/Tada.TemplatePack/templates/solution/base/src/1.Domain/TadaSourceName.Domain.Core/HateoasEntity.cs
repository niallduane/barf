using System.Collections.Generic;

namespace TadaSourceName.Domain.Core;

public class HateoasEntity
{
    public HateoasEntity(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
    public List<Link>? Links { get; set; }
}

public class Link
{
    public Link(string rel, string href, string protocol)
    {
        Rel = rel;
        Href = href;
        Protocol = protocol;
    }

    public string Rel { get; set; }
    public string Href { get; set; }
    public string Protocol { get; set; }
}
