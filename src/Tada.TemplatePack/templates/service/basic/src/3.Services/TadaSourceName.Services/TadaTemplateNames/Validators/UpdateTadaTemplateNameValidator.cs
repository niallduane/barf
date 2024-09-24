using FluentValidation;

using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;

namespace TadaSourceName.Services.TadaTemplateNames.Validators;

public class UpdateTadaTemplateNameValidator : AbstractValidator<(string tadatemplatenameId, PatchRequest<UpdateTadaTemplateNameRequest> request)>
{
    public UpdateTadaTemplateNameValidator(ITadaTemplateNameRepository tadatemplatenameRepository)
    {
    }
}