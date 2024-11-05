using FluentValidation;

using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;
using TadaSourceName.Domain.Core;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 


namespace TadaSourceName.Services.TadaTemplateNames.Validators;

public class UpsertTadaTemplateNameValidator: AbstractValidator<(TadaIdType tadatemplatenameId, UpsertTadaTemplateNameRequest request)>
{
    public UpsertTadaTemplateNameValidator(ITadaTemplateNameRepository tadatemplatenameRepository)
    {
    }
}
