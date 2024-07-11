using System;
using System.Collections.Generic;

using TadaSourceName.Domain.Core;

namespace TadaSourceName.Domain.Services.TadaTemplateNames.Models;

public class GetTadaTemplateNameResponse : BaseTadaTemplateNameResponse
{
    public GetTadaTemplateNameResponse(string id) : base(id)
    {
    }
}
