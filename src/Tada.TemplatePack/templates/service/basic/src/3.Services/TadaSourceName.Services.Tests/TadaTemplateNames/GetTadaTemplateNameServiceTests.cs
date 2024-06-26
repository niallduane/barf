using TadaSourceName.Domain.Services.TadaTemplateNames.Models;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class GetTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{
    public GetTadaTemplateNameServiceTests() : base()
    {

    }

    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public async Task GetTadaTemplateName_Success(string id)
    {
        var result = await context.GetTadaTemplateName(id);

        Assert.NotNull(result);

        //todo: check that result is returning the correct TadaTemplateName
    }

    [Fact]
    public async Task ListTadaTemplateNames_Success()
    {
        var searchFilter = new ListTadaTemplateNameRequest
        {

        };

        var result = await context.ListTadaTemplateNames(searchFilter);

        Assert.NotNull(result);

        //todo: check that result is returning the correct TadaTemplateNames
    }
}
