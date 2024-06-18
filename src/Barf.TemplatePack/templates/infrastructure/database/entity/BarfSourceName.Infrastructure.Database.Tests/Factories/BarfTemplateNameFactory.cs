using BarfSourceName.Infrastructure.Database.Entities;

using Bogus;

namespace BarfSourceName.Infrastructure.Database.Tests.Factories;

public class BarfTemplateNameFactory : Faker<BarfTemplateName>
{
    public BarfTemplateNameFactory()
    {
        RuleFor(entity => entity.BarfTemplateNameId, (f, u) => Guid.NewGuid());
        // Add Rules
    }
}
