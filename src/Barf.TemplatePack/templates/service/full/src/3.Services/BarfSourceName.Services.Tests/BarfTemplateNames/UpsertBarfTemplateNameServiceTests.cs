using BarfSourceName.Domain.Services.BarfTemplateNames.Models;

using Bogus;

using Moq;

namespace BarfSourceName.Services.Tests.BarfTemplateNames;

public class UpsertBarfTemplateNameServiceTests : BarfTemplateNameServiceFixture
{
    private readonly Faker<UpsertBarfTemplateNameRequest> barftemplatename = new Faker<UpsertBarfTemplateNameRequest>();

    public UpsertBarfTemplateNameServiceTests() : base()
    {

    }

    [Fact]
    public async Task UpsertUser_Create_Success()
    {
        mockBarfTemplateNameRepository.Setup(x => x.GetBarfTemplateName(It.IsAny<Guid>()))
            .ReturnsAsync((Guid barftemplatenameId) => null);

        var request = barftemplatename.Generate();

        var result = await context.UpsertBarfTemplateName(Guid.NewGuid().ToString(), request);

        Assert.NotNull(result);
        Assert.False(result.IsEdit);
    }

    [Fact]
    public async Task UpsertUser_Edit_Success()
    {
        var expected = barftemplatenameFactory.Generate();

        mockBarfTemplateNameRepository.Setup(x => x.GetBarfTemplateName(It.IsAny<Guid>()))
            .ReturnsAsync((Guid barftemplatenameId) => expected);

        var request = barftemplatename.Generate();

        var result = await context.UpsertBarfTemplateName(Guid.NewGuid().ToString(), request);

        Assert.NotNull(result);
        Assert.True(result.IsEdit);
    }
}
