using BarfSourceName.Domain.Core;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;


namespace BarfSourceName.Presentation.Api.Attributes;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class FromRequestPatchAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider, IModelBinderProvider
{
    public BindingSource BindingSource => BindingSource.Body;

    public string? Name { get; set; }

    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        // Check if the target type is Dictionary<string, object>
        if (context.Metadata.ModelType == typeof(PatchRequest<>))
        {
            return new BinderTypeModelBinder(typeof(RequestPatchBinder));
        }

        return null;
    }
}


public class RequestPatchBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }
        if (bindingContext.BindingSource != BindingSource.Body)
        {
            return;
        }

        var request = bindingContext.HttpContext.Request;

        // Ensure request body can be read
        if (!request.Body.CanRead)
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }

        // Read the request body
        string requestBody;
        using (var reader = new StreamReader(request.Body))
        {
            requestBody = await reader.ReadToEndAsync();
        }
        Type type = bindingContext.ModelMetadata.ModelType.GetGenericArguments()[0];
        var result = Json.Deserialize(requestBody, type);

        bindingContext.Result = ModelBindingResult.Success(result);
    }
}


public class RequestPatchBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        return new RequestPatchBinder();
    }
}

public class RequestPatchOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
        {
            return;
        }

        foreach (var parameter in context.ApiDescription.ParameterDescriptions)
        {
            var fromBodyGenericAttribute = parameter.CustomAttributes()
                .FirstOrDefault(attr => attr.GetType() == typeof(FromRequestPatchAttribute));

            if (fromBodyGenericAttribute != null)
            {
                var openApiParameter = operation.Parameters
                    .FirstOrDefault(p => p.Name == parameter.Name);

                if (openApiParameter != null)
                {
                    operation.Parameters.Remove(openApiParameter);
                }

                var modelType = parameter.ModelMetadata.ModelType.GetGenericArguments()[0];
                operation.RequestBody = new OpenApiRequestBody
                {
                    Content =
                        {
                            ["application/json"] = new OpenApiMediaType
                            {
                                Schema = context.SchemaGenerator.GenerateSchema(
                                    modelType,
                                    context.SchemaRepository)
                            }
                        }
                };
            }
        }
    }
}
