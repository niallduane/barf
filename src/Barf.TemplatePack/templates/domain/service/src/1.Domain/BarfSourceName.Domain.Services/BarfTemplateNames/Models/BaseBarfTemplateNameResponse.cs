using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BarfSourceName.Domain.Core;

namespace BarfSourceName.Domain.Services.BarfTemplateNames.Models;

public abstract class BaseBarfTemplateNameResponse : HateoasEntity
{
    protected BaseBarfTemplateNameResponse(string id) : base(id)
    {
    }
}