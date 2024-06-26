using Microsoft.AspNetCore.Mvc;
using TadaSourceName.Domain.Core;

namespace TadaSourceName.Presentation.Api.Controllers;

/// <summary>
/// A base controller with Hateoas link methods
/// </summary>
public class HateoasController : ControllerBase
{
    /// <summary>
    /// Generator for links in responses
    /// </summary>
    protected LinkGenerator LinkGenerator { get; }

    /// <summary>
    /// The "self" method name to GET the entity
    /// <br/>
    /// Usually denoted with nameof()
    /// <br/>
    /// Use null here if not allowed
    /// </summary>
    protected virtual string? SelfLinkMethodName { get; }

    /// <summary>
    /// The "update" method name to PATCH the entity
    /// <br/>
    /// Usually denoted with nameof()
    /// <br/>
    /// Use null here if not allowed
    /// </summary>
    protected virtual string? UpdateLinkMethodName { get; }

    /// <summary>
    /// The "delete" method name to DELETE the entity
    /// <br/>
    /// Usually denoted with nameof()
    /// <br/>
    /// Use null here if not allowed
    /// </summary>
    protected virtual string? DeleteLinkMethodName { get; }

    public HateoasController(LinkGenerator linkGenerator)
    {
        LinkGenerator = linkGenerator;
    }

    /// <summary>
    /// Adds links to the entity passed in
    /// </summary>
    /// <typeparam name="T">The hateoas entity of the controller</typeparam>
    /// <param name="entity">The entity to apply links to and get the ID from</param>
    protected void ApplyLinks<T>(T entity) where T : HateoasEntity
    {
        ApplyLinks(entity, SelfLinkMethodName, UpdateLinkMethodName, DeleteLinkMethodName);
    }

    protected void ApplyLinks<T>(T entity, string? selfLinkMethodName, string? updateLinkMethodName, string? deleteLinkMethodName, string? controller = null) where T : HateoasEntity
    {
        entity.Links = new List<Link>();
        if (selfLinkMethodName != null && !string.IsNullOrEmpty(entity.Id))
        {
            entity.Links.Add(new Link("self", LinkGenerator.GetUriByAction(HttpContext, selfLinkMethodName, controller: controller, values: new { id = entity.Id }, scheme: "https")!, "GET"));
        }
        if (updateLinkMethodName != null && !string.IsNullOrEmpty(entity.Id))
        {
            entity.Links.Add(new Link("update", LinkGenerator.GetUriByAction(HttpContext, updateLinkMethodName, controller: controller, values: new { id = entity.Id }, scheme: "https")!, "PATCH"));
        }
        if (deleteLinkMethodName != null && !string.IsNullOrEmpty(entity.Id))
        {
            entity.Links.Add(new Link("delete", LinkGenerator.GetUriByAction(HttpContext, deleteLinkMethodName, controller: controller, values: new { id = entity.Id }, scheme: "https")!, "DELETE"));
        }
    }
}
