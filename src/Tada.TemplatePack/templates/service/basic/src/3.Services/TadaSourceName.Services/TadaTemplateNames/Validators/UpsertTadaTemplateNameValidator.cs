using FluentValidation;

using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;

namespace TadaSourceName.Services.TadaTemplateNames.Validators;

public class UpsertTadaTemplateNameValidator: AbstractValidator<(string tadatemplatenameId, UpsertTadaTemplateNameRequest request)>
{
    public UpsertTadaTemplateNameValidator(ITadaTemplateNameRepository tadatemplatenameRepository)
    {
    }
}
