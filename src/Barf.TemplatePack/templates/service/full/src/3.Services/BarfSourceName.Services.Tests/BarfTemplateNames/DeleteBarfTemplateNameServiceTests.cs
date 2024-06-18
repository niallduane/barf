using Moq;

namespace BarfSourceName.Services.Tests.BarfTemplateNames;

public class DeleteBarfTemplateNameServiceTests : BarfTemplateNameServiceFixture
{

    public DeleteBarfTemplateNameServiceTests() : base()
    {

    }

    [Fact]
    public async Task DeleteBarfTemplateName_Success()
    {
        var expected = Guid.NewGuid();
        mockBarfTemplateNameRepository.Setup(x => x.Delete(It.IsAny<Guid>()));
        var result = await context.DeleteBarfTemplateName(expected.ToString());

        Assert.NotNull(result);
        //todo: check that delete was successful
    }
}
