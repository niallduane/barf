using TadaSourceName.Domain.Core;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 

namespace TadaSourceName.Domain.Services.TadaTemplateNames.Models;

public class UpdateTadaTemplateNameResponse : BaseTadaTemplateNameResponse
{
    public UpdateTadaTemplateNameResponse(TadaIdType id) : base(id)
    {
    }
}
