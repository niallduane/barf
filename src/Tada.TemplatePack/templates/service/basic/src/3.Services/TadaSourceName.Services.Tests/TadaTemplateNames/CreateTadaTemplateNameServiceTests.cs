using TadaSourceName.Domain.Services.TadaTemplateNames.Models;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class CreateTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{
    public CreateTadaTemplateNameServiceTests() : base()
    {
    }

    [Fact(Skip = "todo: check that create was successful")]
    public async Task CreateTadaTemplateName_Success()
    {
        var request = new CreateTadaTemplateNameRequest
        {

        };

        var result = await context.CreateTadaTemplateName(request);

        Assert.NotNull(result);
        //todo: check that create was successful
    }
}
