using System;
using System.Collections.Generic;

using TadaSourceName.Domain.Core;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 

namespace TadaSourceName.Domain.Services.TadaTemplateNames.Models;

public class ListTadaTemplateNameItem : HateoasEntity
{
    public ListTadaTemplateNameItem(TadaIdType id) : base(id.ToString())
    {
    }
}
