using TadaSourceName.Domain.Services.TadaTemplateNames.Models;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class UpsertTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{
    public UpsertTadaTemplateNameServiceTests() : base()
    {

    }

    [Fact(Skip = "todo: check that upsert was successful")]
    public async Task UpsertTadaTemplateName_Success()
    {
        string id = "";
        var request = new UpsertTadaTemplateNameRequest
        {

        };

        var result = await context.UpsertTadaTemplateName(id, request);

        Assert.NotNull(result);
        //todo: check that create was successful
    }
}
