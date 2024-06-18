using System;
using System.Collections.Generic;

using BarfSourceName.Domain.Core;

namespace BarfSourceName.Domain.Services.BarfTemplateNames.Models;

public class GetBarfTemplateNameResponse : HateoasEntity
{
    public GetBarfTemplateNameResponse(string id) : base(id)
    {
    }
}
