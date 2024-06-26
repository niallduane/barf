using TadaSourceName.Infrastructure.Database.Entities;

using Bogus;

namespace TadaSourceName.Infrastructure.Database.Tests.Factories;

public class TadaTemplateNameFactory : Faker<TadaTemplateName>
{
    public TadaTemplateNameFactory()
    {
        RuleFor(entity => entity.TadaTemplateNameId, (f, u) => Guid.NewGuid());
        // Add Rules
    }
}
