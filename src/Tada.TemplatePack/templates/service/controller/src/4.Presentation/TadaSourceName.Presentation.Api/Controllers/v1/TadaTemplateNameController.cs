using TadaSourceName.Domain.Core;
using TadaSourceName.Domain.Services.TadaTemplateNames;
using TadaSourceName.Domain.Services.TadaTemplateNames.Models;
using TadaSourceName.Presentation.Api.Attributes;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace TadaSourceName.Presentation.Api.Controllers.v1;

[ApiController]
[Route("v{version:apiVersion}/[controller]s")]
[ApiVersion("1")]
public class TadaTemplateNameController : HateoasController
{
    private readonly ITadaTemplateNameService _tadatemplatenameService;
    protected override string? SelfLinkMethodName => nameof(GetTadaTemplateName);
    protected override string? UpdateLinkMethodName => nameof(UpdateTadaTemplateName);
    protected override string? DeleteLinkMethodName => nameof(DeleteTadaTemplateName);


    public TadaTemplateNameController(ITadaTemplateNameService tadatemplatenameService, LinkGenerator linkGenerator) : base(linkGenerator)
    {
        this._tadatemplatenameService = tadatemplatenameService;
    }

    /// <summary>
    /// Get TadaTemplateName by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [SwaggerOperation(OperationId = "GetTadaTemplateName", Description = "Get TadaTemplateName by id")]
    [ProducesResponseType(typeof(ApiResponse<GetTadaTemplateNameResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<ApiResponse<GetTadaTemplateNameResponse>> GetTadaTemplateName([FromRoute] string id)
    {
        var item = await _tadatemplatenameService.GetTadaTemplateName(id);
        ApplyLinks(item);
        return new ApiResponse<GetTadaTemplateNameResponse>(StatusCodes.Status200OK, item);
    }

    /// <summary>
    /// Get List of TadaTemplateNames
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(OperationId = "ListTadaTemplateNames", Description = "Get List of TadaTemplateNames")]
    [ProducesResponseType(typeof(PagedApiResponse<ListTadaTemplateNameItem>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<PagedApiResponse<ListTadaTemplateNameItem>> ListTadaTemplateNames([FromQuery] ListTadaTemplateNameRequest request)
    {
        var items = await _tadatemplatenameService.ListTadaTemplateNames(request);
        items.ForEach(v => ApplyLinks(v));
        return new PagedApiResponse<ListTadaTemplateNameItem>(StatusCodes.Status200OK, items, this.LinkGenerator.GetUriByAction(HttpContext, nameof(ListTadaTemplateNames))!);
    }


    /// <summary>
    /// Create TadaTemplateName
    /// </summary>
    /// <param name="body"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerOperation(OperationId = "CreateTadaTemplateName", Description = "Create TadaTemplateName")]
    [ProducesResponseType(typeof(ApiResponse<CreateTadaTemplateNameResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTadaTemplateName([FromBody] CreateTadaTemplateNameRequest body)
    {
        var item = await _tadatemplatenameService.CreateTadaTemplateName(body);
        ApplyLinks(item);

        return Created(nameof(CreateTadaTemplateName), new ApiResponse<CreateTadaTemplateNameResponse>(StatusCodes.Status201Created, item));
    }

    /// <summary>
    /// Create or replace TadaTemplateName
    /// </summary>
    /// <param name="id"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [SwaggerOperation(OperationId = "UpsertTadaTemplateName", Description = "Upsert TadaTemplateName")]
    [ProducesResponseType(typeof(ApiResponse<CreateTadaTemplateNameResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<CreateTadaTemplateNameResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpsertTadaTemplateName([FromRoute] string id, [FromBody] UpsertTadaTemplateNameRequest body)
    {
        var item = await _tadatemplatenameService.UpsertTadaTemplateName(id, body);
        ApplyLinks(item.Response);

        return item.IsEdit
            ? Ok(new ApiResponse<UpsertTadaTemplateNameResponse>(StatusCodes.Status200OK, item.Response))
            : Created(nameof(UpsertTadaTemplateName), new ApiResponse<UpsertTadaTemplateNameResponse>(StatusCodes.Status201Created, item.Response));
    }

    /// <summary>
    /// Update TadaTemplateName
    /// </summary>
    /// <param name="id"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    [SwaggerOperation(OperationId = "UpdateTadaTemplateName", Description = "Update TadaTemplateName")]

    [ProducesResponseType(typeof(ApiResponse<UpdateTadaTemplateNameResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateTadaTemplateName([FromRoute] string id, [FromRequestPatch] PatchRequest<UpdateTadaTemplateNameRequest> body)
    {
        if (!this.TryValidateModel(body.Model!))
        {
            return ValidationProblem();
        }
        
        var item = await _tadatemplatenameService.UpdateTadaTemplateName(id, body);
        ApplyLinks(item);
        return Ok(new ApiResponse<UpdateTadaTemplateNameResponse>(StatusCodes.Status200OK, item));
    }

    /// <summary>
    /// Delete TadaTemplateName by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [SwaggerOperation(OperationId = "DeleteTadaTemplateName", Description = "Delete TadaTemplateName")]
    [ProducesResponseType(typeof(ApiResponse<DeleteTadaTemplateNameResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<ApiResponse<DeleteTadaTemplateNameResponse>> DeleteTadaTemplateName([FromRoute] string id)
    {
        var response = await _tadatemplatenameService.DeleteTadaTemplateName(id);
        return new ApiResponse<DeleteTadaTemplateNameResponse>(StatusCodes.Status200OK, response);
    }
}