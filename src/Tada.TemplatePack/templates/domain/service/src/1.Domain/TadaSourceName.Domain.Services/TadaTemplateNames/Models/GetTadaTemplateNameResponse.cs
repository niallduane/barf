using System;
using System.Collections.Generic;

using TadaSourceName.Domain.Core;

namespace TadaSourceName.Domain.Services.TadaTemplateNames.Models;

public class GetTadaTemplateNameResponse : HateoasEntity
{
    public GetTadaTemplateNameResponse(string id) : base(id)
    {
    }
}
