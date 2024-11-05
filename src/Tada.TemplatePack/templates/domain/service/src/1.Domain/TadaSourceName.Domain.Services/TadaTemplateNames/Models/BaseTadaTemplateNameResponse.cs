using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TadaSourceName.Domain.Core;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 

namespace TadaSourceName.Domain.Services.TadaTemplateNames.Models;

public abstract class BaseTadaTemplateNameResponse : HateoasEntity
{
    protected BaseTadaTemplateNameResponse(TadaIdType id) : base(id.ToString())
    {
    }
}