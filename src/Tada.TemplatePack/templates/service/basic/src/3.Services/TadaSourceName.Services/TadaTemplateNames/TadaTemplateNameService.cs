#if(use_validators)
using FluentValidation;
#endif
using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
#if(use_repository)
using TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;
#endif
using TadaSourceName.Services.TadaTemplateNames.Mappings;
#if(use_validators)
using TadaSourceName.Services.TadaTemplateNames.Validators;
#endif

namespace TadaSourceName.Services.TadaTemplateNames;

public class TadaTemplateNameService : ITadaTemplateNameService
{
    #if(use_repository)
    private readonly ITadaTemplateNameRepository _tadatemplatenameRepository;
    #endif
    #if(use_validators)
    private readonly CreateTadaTemplateNameValidator _createTadaTemplateNameValidator;
    private readonly UpsertTadaTemplateNameValidator _upsertTadaTemplateNameValidator;
    private readonly UpdateTadaTemplateNameValidator _updateTadaTemplateNameValidator;
    #endif
    public TadaTemplateNameService(
        #if(use_repository)
        ITadaTemplateNameRepository tadatemplatenameRepositoryTadaUseRepositoryComma
        #endif 
        #if(use_validators)
        CreateTadaTemplateNameValidator createTadaTemplateNameValidator, 
        UpsertTadaTemplateNameValidator upsertTadaTemplateNameValidator, 
        UpdateTadaTemplateNameValidator updateTadaTemplateNameValidator
        #endif
        )
    {
        #if(use_repository)
        _tadatemplatenameRepository = tadatemplatenameRepository;
        #endif
        #if(use_validators)
        _createTadaTemplateNameValidator = createTadaTemplateNameValidator;
        _upsertTadaTemplateNameValidator = upsertTadaTemplateNameValidator;
        _updateTadaTemplateNameValidator = updateTadaTemplateNameValidator;
        #endif
    }


    public async Task<GetTadaTemplateNameResponse> GetTadaTemplateName(string tadatemplatenameId)
    {
        #if(use_repository)
        var tadatemplatename = await _tadatemplatenameRepository.GetTadaTemplateName(new Guid(tadatemplatenameId));
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

        return tadatemplatenames.Map(user => user.ToListTadaTemplateNameItem(), expandableProperties);
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
        var result = await _tadatemplatenameRepository.Create(request.ToEntity());
        return result.ToCreateTadaTemplateNameResponse();
        #else
        throw new NotImplementedException();
        #endif
    }

    public async Task<UpdateTadaTemplateNameResponse> UpdateTadaTemplateName(string tadatemplatenameId, PatchRequest<UpdateTadaTemplateNameRequest> request)
    {
        #if(use_validators)
        await _updateTadaTemplateNameValidator.ValidateAndThrowAsync((tadatemplatenameId, request));
        #endif
        #if(use_repository)
        var result = await _tadatemplatenameRepository.Update(new Guid(tadatemplatenameId), request.ToEntityProperties());
        return result.ToUpdateTadaTemplateNameResponse();
        #else
        throw new NotImplementedException();
        #endif
    }


    public async Task<UpsertResult<UpsertTadaTemplateNameResponse>> UpsertTadaTemplateName(string tadatemplatenameId, UpsertTadaTemplateNameRequest request)
    {
        #if(use_validators)
        await _upsertTadaTemplateNameValidator.ValidateAndThrowAsync((tadatemplatenameId, request));
        #endif
        #if(use_repository)
        var user = await _tadatemplatenameRepository.GetTadaTemplateName(new Guid(tadatemplatenameId));
        if (user == null)
        {
            var result = await _tadatemplatenameRepository.Create(request.ToEntity());
            return new UpsertResult<UpsertTadaTemplateNameResponse>(result.ToUpsertTadaTemplateNameResponse(), false);
        }

        var updateResult = await _tadatemplatenameRepository.Update(new Guid(tadatemplatenameId), request.ToEntityProperties());
        return new UpsertResult<UpsertTadaTemplateNameResponse>(updateResult.ToUpsertTadaTemplateNameResponse(), true);
        #else
        throw new NotImplementedException();
        #endif
    }

    public async Task<DeleteTadaTemplateNameResponse> DeleteTadaTemplateName(string tadatemplatenameId)
    {
        #if(use_repository)
        await _tadatemplatenameRepository.Delete(new Guid(tadatemplatenameId));
        return new DeleteTadaTemplateNameResponse
        {

        };
        #else
        throw new NotImplementedException();
        #endif
    }
}
