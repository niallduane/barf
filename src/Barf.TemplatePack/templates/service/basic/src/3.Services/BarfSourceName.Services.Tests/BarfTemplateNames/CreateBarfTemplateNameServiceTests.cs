using BarfSourceName.Domain.Services.BarfTemplateNames.Models;

namespace BarfSourceName.Services.Tests.BarfTemplateNames;

public class CreateBarfTemplateNameServiceTests : BarfTemplateNameServiceFixture
{
    public CreateBarfTemplateNameServiceTests() : base()
    {
    }

    [Fact(Skip = "todo: check that create was successful")]
    public async Task CreateBarfTemplateName_Success()
    {
        var request = new CreateBarfTemplateNameRequest
        {

        };

        var result = await context.CreateBarfTemplateName(request);

        Assert.NotNull(result);
        //todo: check that create was successful
    }
}
