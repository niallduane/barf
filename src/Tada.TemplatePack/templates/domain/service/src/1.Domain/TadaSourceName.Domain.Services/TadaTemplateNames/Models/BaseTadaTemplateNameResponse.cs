using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TadaSourceName.Domain.Core;

namespace TadaSourceName.Domain.Services.TadaTemplateNames.Models;

public abstract class BaseTadaTemplateNameResponse : HateoasEntity
{
    protected BaseTadaTemplateNameResponse(string id) : base(id)
    {
    }
}