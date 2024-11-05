using TadaSourceName.Infrastructure.Database.Entities;

using Bogus;

namespace TadaSourceName.Infrastructure.Database.Tests.Factories;

public class TadaTemplateNameFactory : Faker<TadaTemplateName>
{
    public TadaTemplateNameFactory()
    {
        // Add Rules
        #if(idType == "Guid")
            RuleFor(entity => entity.TadaTemplateNameId, (f, u) => Guid.NewGuid());
        #else
            RuleFor(entity => entity.TadaTemplateNameId, (f, u) => default);
        #endif
    }
}
