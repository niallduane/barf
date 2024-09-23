using TadaSourceName.Domain.Services.TadaTemplateNames.Models;

using Bogus;

using Moq;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class UpsertTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{
    private readonly Faker<UpsertTadaTemplateNameRequest> tadatemplatename = new Faker<UpsertTadaTemplateNameRequest>();

    public UpsertTadaTemplateNameServiceTests() : base()
    {

    }

    [Fact]
    public async Task UpsertUser_Create_Success()
    {
        #if(use_repository)
        mockTadaTemplateNameRepository.Setup(x => x.GetTadaTemplateName(It.IsAny<Guid>()))
            .ReturnsAsync((Guid tadatemplatenameId) => null);

        var request = tadatemplatename.Generate();

        var result = await context.UpsertTadaTemplateName(Guid.NewGuid().ToString(), request);

        Assert.NotNull(result);
        Assert.False(result.IsEdit);
        #endif
    }

    [Fact]
    public async Task UpsertUser_Edit_Success()
    {
        #if(use_repository)
        var expected = tadatemplatenameFactory.Generate();

        mockTadaTemplateNameRepository.Setup(x => x.GetTadaTemplateName(It.IsAny<Guid>()))
            .ReturnsAsync((Guid tadatemplatenameId) => expected);

        var request = tadatemplatename.Generate();

        var result = await context.UpsertTadaTemplateName(Guid.NewGuid().ToString(), request);

        Assert.NotNull(result);
        Assert.True(result.IsEdit);
        #else
        throw new NotImplementedException();
        #endif
    }
}
