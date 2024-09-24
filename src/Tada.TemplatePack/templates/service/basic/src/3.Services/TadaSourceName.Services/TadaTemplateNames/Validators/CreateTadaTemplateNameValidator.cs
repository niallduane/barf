using FluentValidation;

using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;

namespace TadaSourceName.Services.TadaTemplateNames.Validators;

public class CreateTadaTemplateNameValidator: AbstractValidator<CreateTadaTemplateNameRequest>
{
    public CreateTadaTemplateNameValidator(ITadaTemplateNameRepository tadaTemplateNameRepository)
    {
    }
}
