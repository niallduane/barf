using FluentValidation;

using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 

namespace TadaSourceName.Services.TadaTemplateNames.Validators;

public class UpdateTadaTemplateNameValidator : AbstractValidator<(TadaIdType tadatemplatenameId, PatchRequest<UpdateTadaTemplateNameRequest> request)>
{
    public UpdateTadaTemplateNameValidator(ITadaTemplateNameRepository tadatemplatenameRepository)
    {
    }
}