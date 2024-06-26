using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using TadaSourceName.Domain.Core.Extensions;

namespace TadaSourceName.Domain.Core;

public class ExpandProperty<T, TProperty>
{
    public ExpandProperty(string key, Expression<Func<T, TProperty>>? predicate)
    {
        this.Predicate = predicate;
        this.Key = key;

    }
    public string Key { get; } = string.Empty;
    public Expression<Func<T, TProperty>>? Predicate { get; }
}

public class ExpandProperties<T> : List<ExpandProperty<T, object?>>
{
    private readonly BaseListRequest _request;
    public ExpandProperties(BaseListRequest request)
    {
        _request = request;
    }
    // /// <summary>
    // /// Converts the Expand property into a dictionary of properties and Set all properties that are not in the expand string to null
    // /// </summary>
    public T SetExpandPropertiesInObject(T obj)
    {
        var requestedExpandableProps = (_request.Expand ?? "").Split(",");
        requestedExpandableProps = requestedExpandableProps.Select(prop => prop.Trim()).ToArray();
        this.Where(prop => !requestedExpandableProps.Has(prop.Key))
            .Where(prop => prop.Predicate != null)
            .ToList()
            .ForEach(prop => SetPropertyAsNull(obj, prop.Predicate!));

        return obj;
    }
    private static void SetPropertyAsNull(T obj, Expression<Func<T, object?>> expression)
    {
        MemberExpression? me;
        switch (expression.Body.NodeType)
        {
            case ExpressionType.Convert:
            case ExpressionType.ConvertChecked:
                me = ((expression.Body is UnaryExpression ue) ? ue.Operand : null) as MemberExpression;
                break;
            default:
                me = expression.Body as MemberExpression;
                break;
        }
        var property = me?.Member as PropertyInfo;
        if (property != null)
        {
            property.SetValue(obj, null);
        }
    }
}
