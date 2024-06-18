using BarfSourceName.Domain.Services.BarfTemplateNames.Models;

namespace BarfSourceName.Services.Tests.BarfTemplateNames;

public class UpsertBarfTemplateNameServiceTests : BarfTemplateNameServiceFixture
{
    public UpsertBarfTemplateNameServiceTests() : base()
    {

    }

    [Fact(Skip = "todo: check that upsert was successful")]
    public async Task UpsertBarfTemplateName_Success()
    {
        string id = "";
        var request = new UpsertBarfTemplateNameRequest
        {

        };

        var result = await context.UpsertBarfTemplateName(id, request);

        Assert.NotNull(result);
        //todo: check that create was successful
    }
}
