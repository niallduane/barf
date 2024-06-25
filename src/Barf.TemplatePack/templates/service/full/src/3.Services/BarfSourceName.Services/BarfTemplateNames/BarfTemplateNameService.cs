using BarfSourceName.Domain.Core;
using BarfSourceName.Domain.Services.BarfTemplateNames;
using BarfSourceName.Domain.Services.BarfTemplateNames.Models;
using BarfSourceName.Infrastructure.Database.Repositories.BarfTemplateNames;
using BarfSourceName.Services.BarfTemplateNames.Mappings;

namespace BarfSourceName.Services.BarfTemplateNames;

public class BarfTemplateNameService : IBarfTemplateNameService
{
    private readonly IBarfTemplateNameRepository _barftemplatenameRepository;
    public BarfTemplateNameService(IBarfTemplateNameRepository barftemplatenameRepository)
    {
        _barftemplatenameRepository = barftemplatenameRepository;
    }


    public async Task<GetBarfTemplateNameResponse> GetBarfTemplateName(string barftemplatenameId)
    {
        var barftemplatename = await _barftemplatenameRepository.GetBarfTemplateName(new Guid(barftemplatenameId));
        if (barftemplatename == null)
        {
            throw new ArgumentNullException("barftemplatenameId");
        }

        return barftemplatename.ToGetBarfTemplateNameResponse();
    }


    public async Task<PagedList<ListBarfTemplateNameItem>> ListBarfTemplateNames(ListBarfTemplateNameRequest request)
    {
        var expandableProperties = new ExpandProperties<ListBarfTemplateNameItem>(request)
        {
            // new(nameof(ListBarfTemplateNameItem.Id), prop => prop.Id),
        };

        var barftemplatenames = await _barftemplatenameRepository.ListBarfTemplateNames(request);

        return barftemplatenames.Map(user => user.ToListBarfTemplateNameItem(), expandableProperties);
    }

    public async Task<CreateBarfTemplateNameResponse> CreateBarfTemplateName(CreateBarfTemplateNameRequest request)
    {
        var result = await _barftemplatenameRepository.Create(request.ToEntity());
        return result.ToCreateBarfTemplateNameResponse();
    }

    public async Task<UpdateBarfTemplateNameResponse> UpdateBarfTemplateName(string barftemplatenameId, PatchRequest<UpdateBarfTemplateNameRequest> request)
    {
        var result = await _barftemplatenameRepository.Update(new Guid(barftemplatenameId), request);
        return result.ToUpdateBarfTemplateNameResponse();
    }


    public async Task<UpsertResult<UpsertBarfTemplateNameResponse>> UpsertBarfTemplateName(string barftemplatenameId, UpsertBarfTemplateNameRequest request)
    {
        var user = await _barftemplatenameRepository.GetBarfTemplateName(new Guid(barftemplatenameId));
        if (user == null)
        {
            var result = await _barftemplatenameRepository.Create(request.ToEntity());
            return new UpsertResult<UpsertBarfTemplateNameResponse>(result.ToUpsertBarfTemplateNameResponse(), false);
        }

        throw new NotImplementedException();
    }

    public async Task<DeleteBarfTemplateNameResponse> DeleteBarfTemplateName(string barftemplatenameId)
    {
        await _barftemplatenameRepository.Delete(new Guid(barftemplatenameId));
        return new DeleteBarfTemplateNameResponse
        {

        };
    }
}
