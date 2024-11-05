using TadaSourceName.Domain.Core;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 

namespace TadaSourceName.Domain.Services.TadaTemplateNames.Models;

public class UpsertTadaTemplateNameResponse : BaseTadaTemplateNameResponse
{
    public UpsertTadaTemplateNameResponse(TadaIdType id) : base(id)
    {
    }
}
