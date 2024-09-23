using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;

using Bogus;

using Moq;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class UpdateTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{
    private readonly Faker<UpdateTadaTemplateNameRequest> tadatemplatename = new Faker<UpdateTadaTemplateNameRequest>();

    public UpdateTadaTemplateNameServiceTests() : base()
    {

    }

    [Fact]
    public async Task UpdateTadaTemplateName_Success()
    {
        #if(use_repository)
        mockTadaTemplateNameRepository.Setup(x => x.GetTadaTemplateName(It.IsAny<Guid>()))
            .ReturnsAsync((Guid tadatemplatenameId) => null);

        var request = new PatchRequest<UpdateTadaTemplateNameRequest>();

        var result = await context.UpdateTadaTemplateName(Guid.NewGuid().ToString(), request);

        Assert.NotNull(result);
        #else
        throw new NotImplementedException();
        #endif
    }
}