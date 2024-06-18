using BarfSourceName.Domain.Services.BarfTemplateNames.Models;

namespace BarfSourceName.Services.Tests.BarfTemplateNames;

public class GetBarfTemplateNameServiceTests : BarfTemplateNameServiceFixture
{
    public GetBarfTemplateNameServiceTests() : base()
    {

    }

    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public async Task GetBarfTemplateName_Success(string id)
    {
        var result = await context.GetBarfTemplateName(id);

        Assert.NotNull(result);

        //todo: check that result is returning the correct BarfTemplateName
    }

    [Fact]
    public async Task ListBarfTemplateNames_Success()
    {
        var searchFilter = new ListBarfTemplateNameRequest
        {

        };

        var result = await context.ListBarfTemplateNames(searchFilter);

        Assert.NotNull(result);

        //todo: check that result is returning the correct BarfTemplateNames
    }
}
