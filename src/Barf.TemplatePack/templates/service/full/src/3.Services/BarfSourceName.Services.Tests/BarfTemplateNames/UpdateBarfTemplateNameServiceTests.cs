using BarfSourceName.Domain.Core;
using BarfSourceName.Domain.Services.BarfTemplateNames.Models;

using Bogus;

using Moq;

namespace BarfSourceName.Services.Tests.BarfTemplateNames;

public class UpdateBarfTemplateNameServiceTests : BarfTemplateNameServiceFixture
{
    private readonly Faker<UpdateBarfTemplateNameRequest> barftemplatename = new Faker<UpdateBarfTemplateNameRequest>();

    public UpdateBarfTemplateNameServiceTests() : base()
    {

    }

    [Fact]
    public async Task UpdateBarfTemplateName_Success()
    {
        mockBarfTemplateNameRepository.Setup(x => x.GetBarfTemplateName(It.IsAny<Guid>()))
            .ReturnsAsync((Guid barftemplatenameId) => null);

        var request = new PatchRequest<UpdateBarfTemplateNameRequest>();

        var result = await context.UpdateBarfTemplateName(Guid.NewGuid().ToString(), request);

        Assert.NotNull(result);
    }
}