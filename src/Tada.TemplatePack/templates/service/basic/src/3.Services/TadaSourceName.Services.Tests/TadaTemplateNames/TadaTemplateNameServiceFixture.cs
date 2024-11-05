using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames;
using TadaSourceName.Infrastructure.Database.Entities;
using TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;
using TadaSourceName.Infrastructure.Database.Tests.Factories;
using TadaSourceName.Services.TadaTemplateNames;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 
using Moq;

namespace TadaSourceName.Services.Tests.TadaTemplateNames;

public class TadaTemplateNameServiceFixture
{
    #if(use_repository)
    protected readonly TadaTemplateNameFactory tadatemplatenameFactory = new TadaTemplateNameFactory();
    protected readonly Mock<ITadaTemplateNameRepository> mockTadaTemplateNameRepository = new();
    #endif
    protected readonly ITadaTemplateNameService context;

    public TadaTemplateNameServiceFixture()
    {
        #if(use_repository)
        mockTadaTemplateNameRepository.Setup(x => x.CreateTadaTemplateName(It.IsAny<TadaTemplateName>()))
            .ReturnsAsync((TadaTemplateName tadatemplatename) =>
            {
                tadatemplatename.TadaTemplateNameId = new TadaIdType();
                return tadatemplatename;
            });

        mockTadaTemplateNameRepository.Setup(x => x.UpdateTadaTemplateName(It.IsAny<TadaIdType>(), It.IsAny<Dictionary<string, object?>>()))
            .ReturnsAsync((TadaIdType id, Dictionary<string, object?> newValues) =>
            {
                return new TadaTemplateName
                {
                    TadaTemplateNameId = id
                };
            });

        mockTadaTemplateNameRepository.Setup(x => x.GetTadaTemplateName(It.IsAny<TadaIdType>()))
            .ReturnsAsync((TadaIdType tadatemplatenameId) =>
            {
                var tadatemplatename = tadatemplatenameFactory.Generate();
                tadatemplatename.TadaTemplateNameId = tadatemplatenameId;
                return tadatemplatename;
            });

        mockTadaTemplateNameRepository.Setup(x => x.ListTadaTemplateNames(It.IsAny<BaseListRequest>()))
            .ReturnsAsync((BaseListRequest request) =>
            {
                var items = tadatemplatenameFactory.Generate(50);
                return new PagedList<TadaTemplateName>(items, 50, 0, 50);
            });
        #if(use_validators)
        context = new TadaTemplateNameService(
            mockTadaTemplateNameRepository.Object,
            new(mockTadaTemplateNameRepository.Object), 
            new(mockTadaTemplateNameRepository.Object), 
            new(mockTadaTemplateNameRepository.Object)
        );
        #else
        context = new TadaTemplateNameService(mockTadaTemplateNameRepository.Object);
        #endif
;
        #elif(use_validators)
        context = new TadaTemplateNameService(new(), new(), new());
        #else
        context = new TadaTemplateNameService();
        #endif
    }
}
