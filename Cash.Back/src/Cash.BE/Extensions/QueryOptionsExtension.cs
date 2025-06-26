using System.Collections;
using System.Linq.Expressions;
using Cash.BE.Attributes;
using Cash.BE.Helpers;
using Cash.BE.Querying;
using Cash.BE.Request;

namespace Cash.BE.Extensions;

public static class QueryOptionsExtension
{
    private static ParameterExpression? _parameter;
    private static MemberExpression? _member;
    private static Type? _typeProperty;

    public static Expression<Func<T, bool>>? GenerateExpressionByList<T>(this QueryOptions<T> options,
        List<FilterField> filters)
    {
        Expression? expression = null;
        
        filters.ForEach(filter =>
        {
            var expressionCreate = options.GenerateExpression(filter);
            
            expression = expression is null ? expressionCreate : Expression.AndAlso(expression, expressionCreate);
            
        });
        
        
        return Expression.Lambda<Func<T, bool>>(expression ?? Expression.Constant(false), _parameter!);
    }
    public static Expression<Func<T, bool>> GenerateExpression<T>(this QueryOptions<T> options, FilterField filter)
    {
        var type = typeof(T);
        var property = type.GetProperty(filter.FieldName);
        
        
        if(property is null) throw new InvalidOperationException(ErrorMessage.FieldNotFound);
        
        var attribute = Attribute.GetCustomAttribute(property, typeof(AllowedFilterAttribute));
        
        if(attribute is null) throw new InvalidOperationException(ErrorMessage.FieldNotAllowed);
        
        _parameter = Expression.Parameter(typeof(T), "x");
        
        _member = Expression.Property(_parameter, property);
        
        _typeProperty = Nullable.GetUnderlyingType(_member.Type) ?? _member.Type;
        var body = CreateExpression(filter);
        
        return Expression.Lambda<Func<T, bool>>(body, _parameter);
        
    }
    
    private static Expression  CreateExpression(FilterField filter)
    {
        
        var convertValue = Convert.ChangeType(filter.FieldValue, _typeProperty!);
        if (convertValue is null) throw new InvalidCastException();
        
        var constExpressionValue =  Expression.Constant(convertValue);
        return filter.Method switch
        {
            Allowedfilter.Equal => Expression.Equal(_member!, constExpressionValue),
            Allowedfilter.NotEqual => Expression.NotEqual(_member!, constExpressionValue),
            Allowedfilter.GreaterThan => Expression.GreaterThan(_member!, constExpressionValue),
            Allowedfilter.LessThan => Expression.LessThan(_member!, constExpressionValue),
            Allowedfilter.GreaterThanOrEqual => Expression.GreaterThanOrEqual(_member!, constExpressionValue),
            Allowedfilter.LessThanOrEqual => Expression.LessThanOrEqual(_member!, constExpressionValue),
            Allowedfilter.Range => GenerateRange(filter),
            Allowedfilter.Contains => Expression.Call(_member!, "Contains", Type.EmptyTypes, constExpressionValue),
            _ => throw new NotSupportedException($"Invalid filter type: {filter.Method}")
        };
    }
    private static MethodCallExpression GenerateRange(FilterField filter)
    {
        if(filter.FieldValues is null || !filter.FieldValues.Any()) throw new InvalidOperationException($"{_parameter?.GetType().Name} {filter.Method} this method required List values");
            var methodContains = typeof(List<>)
                .MakeGenericType(_typeProperty!)
                .GetMethod("Contains", [_typeProperty!]);
        
            var listConvert = ConvertToListOfType(filter.FieldValues);
        var listConst = Expression.Constant(listConvert);
        return Expression.Call(listConst, methodContains ?? throw new InvalidOperationException($"Error get method contains for {_member!.Member.Name}"), _member!);
        
    }
    private static object? ConvertToListOfType(IEnumerable<object> values)
    {
        if (_typeProperty is null) return null;
        
            var listType = typeof(List<>).MakeGenericType(_typeProperty);
            var list = (IList)Activator.CreateInstance(listType)!;

            foreach (var value in values)
            {
                var convertido = Convert.ChangeType(value, _typeProperty);
                list?.Add(convertido);
            }

            return list;
        
    }

}