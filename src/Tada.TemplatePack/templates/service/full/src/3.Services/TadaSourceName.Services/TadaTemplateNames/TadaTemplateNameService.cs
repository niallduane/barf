using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Infrastructure.Database.Repositories.TadaTemplateNames;
using TadaSourceName.Services.TadaTemplateNames.Mappings;

namespace TadaSourceName.Services.TadaTemplateNames;

public class TadaTemplateNameService : ITadaTemplateNameService
{
    private readonly ITadaTemplateNameRepository _tadatemplatenameRepository;
    public TadaTemplateNameService(ITadaTemplateNameRepository tadatemplatenameRepository)
    {
        _tadatemplatenameRepository = tadatemplatenameRepository;
    }


    public async Task<GetTadaTemplateNameResponse> GetTadaTemplateName(string tadatemplatenameId)
    {
        var tadatemplatename = await _tadatemplatenameRepository.GetTadaTemplateName(new Guid(tadatemplatenameId));
        if (tadatemplatename == null)
        {
            throw new ArgumentNullException("tadatemplatenameId");
        }

        return tadatemplatename.ToGetTadaTemplateNameResponse();
    }


    public async Task<PagedList<ListTadaTemplateNameItem>> ListTadaTemplateNames(ListTadaTemplateNameRequest request)
    {
        var expandableProperties = new ExpandProperties<ListTadaTemplateNameItem>(request)
        {
            // new(nameof(ListTadaTemplateNameItem.Id), prop => prop.Id),
        };

        var tadatemplatenames = await _tadatemplatenameRepository.ListTadaTemplateNames(request);

        return tadatemplatenames.Map(user => user.ToListTadaTemplateNameItem(), expandableProperties);
    }

    public async Task<CreateTadaTemplateNameResponse> CreateTadaTemplateName(CreateTadaTemplateNameRequest request)
    {
        var result = await _tadatemplatenameRepository.Create(request.ToEntity());
        return result.ToCreateTadaTemplateNameResponse();
    }

    public async Task<UpdateTadaTemplateNameResponse> UpdateTadaTemplateName(string tadatemplatenameId, PatchRequest<UpdateTadaTemplateNameRequest> request)
    {
        var result = await _tadatemplatenameRepository.Update(new Guid(tadatemplatenameId), request);
        return result.ToUpdateTadaTemplateNameResponse();
    }


    public async Task<UpsertResult<UpsertTadaTemplateNameResponse>> UpsertTadaTemplateName(string tadatemplatenameId, UpsertTadaTemplateNameRequest request)
    {
        var user = await _tadatemplatenameRepository.GetTadaTemplateName(new Guid(tadatemplatenameId));
        if (user == null)
        {
            var result = await _tadatemplatenameRepository.Create(request.ToEntity());
            return new UpsertResult<UpsertTadaTemplateNameResponse>(result.ToUpsertTadaTemplateNameResponse(), false);
        }

        throw new NotImplementedException();
    }

    public async Task<DeleteTadaTemplateNameResponse> DeleteTadaTemplateName(string tadatemplatenameId)
    {
        await _tadatemplatenameRepository.Delete(new Guid(tadatemplatenameId));
        return new DeleteTadaTemplateNameResponse
        {

        };
    }
}
