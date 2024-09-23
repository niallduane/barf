using Moq;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class DeleteTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{

    public DeleteTadaTemplateNameServiceTests() : base()
    {

    }

    [Fact]
    public async Task DeleteTadaTemplateName_Success()
    {
        #if(use_repository)
        var expected = Guid.NewGuid();
        mockTadaTemplateNameRepository.Setup(x => x.Delete(It.IsAny<Guid>()));
        var result = await context.DeleteTadaTemplateName(expected.ToString());

        Assert.NotNull(result);
        //todo: check that delete was successful
        #else
        throw new NotImplementedException();
        #endif
    }
}
