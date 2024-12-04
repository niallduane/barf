#if(use_validators)
using FluentValidation;
#endif
using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
#if (TadaIdNameSpace != null) 
using TadaIdNameSpace;
#endif 
#if(use_repository)
using TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;
#endif
using TadaSourceName.Services.TadaTemplateNames.Mappings;
#if(use_validators)
using TadaSourceName.Services.TadaTemplateNames.Validators;
#endif

namespace TadaSourceName.Services.TadaTemplateNames;

public class TadaTemplateNameService(
        #if(use_repository)
        ITadaTemplateNameRepository tadatemplatenameRepositoryTadaUseRepositoryComma
        #endif 
        #if(use_validators)
        CreateTadaTemplateNameValidator createTadaTemplateNameValidator, 
        UpsertTadaTemplateNameValidator upsertTadaTemplateNameValidator, 
        UpdateTadaTemplateNameValidator updateTadaTemplateNameValidator
        #endif
    ) : ITadaTemplateNameService
{
    #if(use_repository)
    private readonly ITadaTemplateNameRepository _tadatemplatenameRepository = tadatemplatenameRepository;
    #endif
    #if(use_validators)
    private readonly CreateTadaTemplateNameValidator _createTadaTemplateNameValidator = createTadaTemplateNameValidator;
    private readonly UpsertTadaTemplateNameValidator _upsertTadaTemplateNameValidator = upsertTadaTemplateNameValidator;
    private readonly UpdateTadaTemplateNameValidator _updateTadaTemplateNameValidator = updateTadaTemplateNameValidator;
    #endif

    public async Task<GetTadaTemplateNameResponse> GetTadaTemplateName(TadaIdType tadatemplatenameId)
    {
        #if(use_repository)
        var tadatemplatename = await _tadatemplatenameRepository.GetTadaTemplateName(tadatemplatenameId);
        if (tadatemplatename == null)
        {
            throw new ArgumentNullException("tadatemplatenameId");
        }

        return tadatemplatename.ToGetTadaTemplateNameResponse();
        #else
        throw new NotImplementedException();
        #endif
    }


    public async Task<PagedList<ListTadaTemplateNameItem>> ListTadaTemplateNames(ListTadaTemplateNameRequest request)
    {
        #if(use_repository)
        var expandableProperties = new ExpandProperties<ListTadaTemplateNameItem>(request)
        {
            // new(nameof(ListTadaTemplateNameItem.Id), prop => prop.Id),
        };

        var tadatemplatenames = await _tadatemplatenameRepository.ListTadaTemplateNames(request);

        return tadatemplatenames.Map(tadatemplatename => tadatemplatename.ToListTadaTemplateNameItem(), expandableProperties);
        #else
        throw new NotImplementedException();
        #endif
    }

    public async Task<CreateTadaTemplateNameResponse> CreateTadaTemplateName(CreateTadaTemplateNameRequest request)
    {
        #if(use_validators)
        await _createTadaTemplateNameValidator.ValidateAndThrowAsync(request);
        #endif
        #if(use_repository)
        var result = await _tadatemplatenameRepository.CreateTadaTemplateName(request.ToEntity());
        return result.ToCreateTadaTemplateNameResponse();
        #else
        throw new NotImplementedException();
        #endif
    }

    public async Task<UpdateTadaTemplateNameResponse> UpdateTadaTemplateName(TadaIdType tadatemplatenameId, PatchRequest<UpdateTadaTemplateNameRequest> request)
    {
        #if(use_validators)
        await _updateTadaTemplateNameValidator.ValidateAndThrowAsync((tadatemplatenameId, request));
        #endif
        #if(use_repository)
        var result = await _tadatemplatenameRepository.UpdateTadaTemplateName(tadatemplatenameId, request.ToEntityProperties());
        return result.ToUpdateTadaTemplateNameResponse();
        #else
        throw new NotImplementedException();
        #endif
    }


    public async Task<UpsertResult<UpsertTadaTemplateNameResponse>> UpsertTadaTemplateName(TadaIdType tadatemplatenameId, UpsertTadaTemplateNameRequest request)
    {
        #if(use_validators)
        await _upsertTadaTemplateNameValidator.ValidateAndThrowAsync((tadatemplatenameId, request));
        #endif
        #if(use_repository)
        var tadatemplatename = await _tadatemplatenameRepository.GetTadaTemplateName(tadatemplatenameId);
        if (tadatemplatename == null)
        {
            var result = await _tadatemplatenameRepository.CreateTadaTemplateName(request.ToEntity());
            return new UpsertResult<UpsertTadaTemplateNameResponse>(result.ToUpsertTadaTemplateNameResponse(), false);
        }

        var updateResult = await _tadatemplatenameRepository.UpdateTadaTemplateName(tadatemplatenameId, request.ToEntityProperties());
        return new UpsertResult<UpsertTadaTemplateNameResponse>(updateResult.ToUpsertTadaTemplateNameResponse(), true);
        #else
        throw new NotImplementedException();
        #endif
    }

    public async Task<DeleteTadaTemplateNameResponse> DeleteTadaTemplateName(TadaIdType tadatemplatenameId)
    {
        #if(use_repository)
        await _tadatemplatenameRepository.DeleteTadaTemplateName(tadatemplatenameId);
        return new DeleteTadaTemplateNameResponse
        {

        };
        #else
        throw new NotImplementedException();
        #endif
    }
}
