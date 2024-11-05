using System;
using System.Collections.Generic;

using TadaSourceName.Domain.Core;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 

namespace TadaSourceName.Domain.Services.TadaTemplateNames.Models;

public class GetTadaTemplateNameResponse : BaseTadaTemplateNameResponse
{
    public GetTadaTemplateNameResponse(TadaIdType id) : base(id)
    {
    }
}
