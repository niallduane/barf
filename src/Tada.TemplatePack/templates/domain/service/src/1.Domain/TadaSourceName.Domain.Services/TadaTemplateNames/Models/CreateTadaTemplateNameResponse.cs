using TadaSourceName.Domain.Core;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 

namespace TadaSourceName.Domain.Services.TadaTemplateNames.Models;

public class CreateTadaTemplateNameResponse : BaseTadaTemplateNameResponse
{
    public CreateTadaTemplateNameResponse(TadaIdType id) : base(id)
    {
    }
}
