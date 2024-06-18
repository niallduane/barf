using BarfSourceName.Domain.Services.BarfTemplateNames.Models;

using Bogus;

namespace BarfSourceName.Services.Tests.BarfTemplateNames;

public class CreateBarfTemplateNameServiceTests : BarfTemplateNameServiceFixture
{
    private readonly Faker<CreateBarfTemplateNameRequest> barftemplatename = new Faker<CreateBarfTemplateNameRequest>();

    public CreateBarfTemplateNameServiceTests() : base()
    {
    }

    [Fact]
    public async Task CreateBarfTemplateName_Success()
    {
        var request = barftemplatename.Generate();

        var result = await context.CreateBarfTemplateName(request);

        Assert.NotNull(result);
        //todo: check that create was successful
    }
}
