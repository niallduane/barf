using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Domain.Core;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 

using Bogus;

using Moq;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class UpsertTadaTemplateNameServiceTests : TadaTemplateNameServiceFixture
{
    private readonly Faker<UpsertTadaTemplateNameRequest> tadatemplatename = new Faker<UpsertTadaTemplateNameRequest>();

    [Fact]
    public async Task UpsertUser_Create_Success()
    {
        #if(use_repository)
        mockTadaTemplateNameRepository.Setup(x => x.GetTadaTemplateName(It.IsAny<TadaIdType>()))
            .ReturnsAsync((TadaIdType tadatemplatenameId) => null);

        var request = tadatemplatename.Generate();

        var result = await context.UpsertTadaTemplateName(TadaIdTypeValue, request);

        Assert.NotNull(result);
        Assert.False(result.IsEdit);
        #endif
    }

    [Fact]
    public async Task UpsertUser_Edit_Success()
    {
        #if(use_repository)
        var expected = tadatemplatenameFactory.Generate();

        mockTadaTemplateNameRepository.Setup(x => x.GetTadaTemplateName(It.IsAny<TadaIdType>()))
            .ReturnsAsync((TadaIdType tadatemplatenameId) => expected);

        var request = tadatemplatename.Generate();

        var result = await context.UpsertTadaTemplateName(TadaIdTypeValue, request);

        Assert.NotNull(result);
        Assert.True(result.IsEdit);
        #else
        throw new NotImplementedException();
        #endif
    }
}
