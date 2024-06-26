using TadaSourceName.Domain.Services.TadaTemplateNames.Models;

using Bogus;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class CreateTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{
    private readonly Faker<CreateTadaTemplateNameRequest> tadatemplatename = new Faker<CreateTadaTemplateNameRequest>();

    public CreateTadaTemplateNameServiceTests() : base()
    {
    }

    [Fact]
    public async Task CreateTadaTemplateName_Success()
    {
        var request = tadatemplatename.Generate();

        var result = await context.CreateTadaTemplateName(request);

        Assert.NotNull(result);
        //todo: check that create was successful
    }
}
