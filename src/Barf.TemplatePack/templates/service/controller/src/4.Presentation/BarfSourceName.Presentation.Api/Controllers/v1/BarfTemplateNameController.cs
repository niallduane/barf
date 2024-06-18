using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

using BarfSourceName.Domain.Services.BarfTemplateNames;
using BarfSourceName.Domain.Core;
using BarfSourceName.Domain.Services.BarfTemplateNames.Models;

namespace BarfSourceName.Presentation.Api.Controllers.v1;

[ApiController]
[Route("v{version:apiVersion}/[controller]s")]
[ApiVersion("1")]
public class BarfTemplateNameController : HateoasController
{
    private readonly IBarfTemplateNameService barftemplatenameService;
    protected override string? SelfLinkMethodName => nameof(GetBarfTemplateName);
    protected override string? UpdateLinkMethodName => "";  //nameof(UpdateBarfTemplateName);
    protected override string? DeleteLinkMethodName => nameof(DeleteBarfTemplateName);


    public BarfTemplateNameController(IBarfTemplateNameService barftemplatenameService, LinkGenerator linkGenerator) : base(linkGenerator)
    {
        this.barftemplatenameService = barftemplatenameService;
    }

    /// <summary>
    /// Get BarfTemplateName by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [SwaggerOperation(OperationId = "GetBarfTemplateName", Description = "Get BarfTemplateName by id")]
    [ProducesResponseType(typeof(ApiResponse<GetBarfTemplateNameResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<ApiResponse<GetBarfTemplateNameResponse>> GetBarfTemplateName([FromRoute] string id)
    {
        var item = await barftemplatenameService.GetBarfTemplateName(id);
        ApplyLinks(item);
        return new ApiResponse<GetBarfTemplateNameResponse>(StatusCodes.Status200OK, item);
    }

    /// <summary>
    /// Get List of BarfTemplateNames
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(OperationId = "ListBarfTemplateNames", Description = "Get List of BarfTemplateNames")]
    [ProducesResponseType(typeof(PagedApiResponse<ListBarfTemplateNameItem>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<PagedApiResponse<ListBarfTemplateNameItem>> ListBarfTemplateNames([FromQuery] ListBarfTemplateNameRequest request)
    {
        var items = await barftemplatenameService.ListBarfTemplateNames(request);
        items.ForEach(v => ApplyLinks(v));
        return new PagedApiResponse<ListBarfTemplateNameItem>(StatusCodes.Status200OK, items, this.LinkGenerator.GetUriByAction(HttpContext, nameof(ListBarfTemplateNames))!);
    }


    /// <summary>
    /// Create BarfTemplateName
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerOperation(OperationId = "CreateBarfTemplateName", Description = "Create BarfTemplateName")]
    [ProducesResponseType(typeof(ApiResponse<CreateBarfTemplateNameResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBarfTemplateName([FromBody] CreateBarfTemplateNameRequest model)
    {
        var item = await barftemplatenameService.CreateBarfTemplateName(model);
        ApplyLinks(item);

        return Created(nameof(CreateBarfTemplateName), new ApiResponse<CreateBarfTemplateNameResponse>(StatusCodes.Status201Created, item));
    }

    /// <summary>
    /// Create or replace BarfTemplateName
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [SwaggerOperation(OperationId = "UpsertBarfTemplateName", Description = "Upsert BarfTemplateName")]
    [ProducesResponseType(typeof(ApiResponse<CreateBarfTemplateNameResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<CreateBarfTemplateNameResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpsertBarfTemplateName([FromRoute] string id, [FromBody] UpsertBarfTemplateNameRequest model)
    {
        var item = await barftemplatenameService.UpsertBarfTemplateName(id, model);
        ApplyLinks(item.Response);

        return item.IsEdit
            ? Ok(new ApiResponse<UpsertBarfTemplateNameResponse>(StatusCodes.Status200OK, item.Response))
            : Created(nameof(UpsertBarfTemplateName), new ApiResponse<UpsertBarfTemplateNameResponse>(StatusCodes.Status201Created, item.Response));
    }

    // /// <summary>
    // /// Update BarfTemplateName
    // /// </summary>
    // /// <returns></returns>
    // [HttpPatch("{id}")]
    // [SwaggerOperation(OperationId = "UpdateBarfTemplateName", Description = "Update BarfTemplateName")]
    // [ProducesResponseType(typeof(ApiResponse<UpdateBarfTemplateNameResponse>), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    // public async Task<ApiResponse<UpdateBarfTemplateNameResponse>> UpdateBarfTemplateName([OpenApiIgnoreParameter, FromHeader] string[] propertiesToUpdate, [FromRoute] string id, [FromBody] UpdateBarfTemplateNameRequest model)
    // {
    //     var request = new PatchBodyRequest<UpdateBarfTemplateNameRequest>(model, propertiesToUpdate);
    //     var item = await barftemplatenameService.UpdateBarfTemplateName(id, request);
    //     ApplyLinks(item);
    //     return new ApiResponse<UpdateBarfTemplateNameResponse>(StatusCodes.Status200OK, true, item);
    // }

    /// <summary>
    /// Delete BarfTemplateName by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [SwaggerOperation(OperationId = "DeleteBarfTemplateName", Description = "Delete BarfTemplateName")]
    [ProducesResponseType(typeof(ApiResponse<DeleteBarfTemplateNameResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<ApiResponse<DeleteBarfTemplateNameResponse>> DeleteBarfTemplateName([FromRoute] string id)
    {
        var response = await barftemplatenameService.DeleteBarfTemplateName(id);
        return new ApiResponse<DeleteBarfTemplateNameResponse>(StatusCodes.Status200OK, response);
    }
}
