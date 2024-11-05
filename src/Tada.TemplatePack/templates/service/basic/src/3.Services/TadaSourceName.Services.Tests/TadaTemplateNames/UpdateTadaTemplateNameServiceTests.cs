using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Domain.Core;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 

using Bogus;

using Moq;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class UpdateTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{
    private readonly Faker<UpdateTadaTemplateNameRequest> tadatemplatename = new Faker<UpdateTadaTemplateNameRequest>();

    [Fact]
    public async Task UpdateTadaTemplateName_Success()
    {
        #if(use_repository)
        var request = new PatchRequest<UpdateTadaTemplateNameRequest>();

        var result = await context.UpdateTadaTemplateName(TadaIdTypeValue, request);

        Assert.NotNull(result);
        #else
        throw new NotImplementedException();
        #endif
    }
}