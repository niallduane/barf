using Moq;
using TadaSourceName.Domain.Core;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 


namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class DeleteTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{

    [Fact]
    public async Task DeleteTadaTemplateName_Success()
    {
        #if(use_repository)
        TadaIdType expected = default;
        mockTadaTemplateNameRepository.Setup(x => x.DeleteTadaTemplateName(It.IsAny<TadaIdType>()));
        var result = await context.DeleteTadaTemplateName(expected);

        Assert.NotNull(result);
        //todo: check that delete was successful
        #else
        throw new NotImplementedException();
        #endif
    }
}
