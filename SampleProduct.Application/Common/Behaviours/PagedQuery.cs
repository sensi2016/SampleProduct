using System.Linq.Expressions;
using System.Reflection;

namespace SampleProduct.Application.Common.Behaviours;

// ReSharper disable once InconsistentNaming
public static class IQueryableExtensions
{
   
    public static IQueryable<T> ToPagedQuery<T>(this IQueryable<T> query, int pageSize, int pageNumber)
    {
        return query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
    }

    public static IQueryable<T> ToPagedQuery<T>(this IQueryable<T> query,IPaging paging)
    {
        return query.Skip(paging.PageSize * (paging.PageNumber - 1)).Take(paging.PageSize);
    }
    public static IQueryable<T> WhereEquals<T>(this IQueryable<T> source, string propertyName, object value)
    {
        if (typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase |
            BindingFlags.Public | BindingFlags.Instance) == null)
        {
            return null;
        }

        ParameterExpression parameter = Expression.Parameter(typeof(T), "item");
        Expression whereProperty = Expression.Property(parameter, propertyName);
        Expression constant = Expression.Constant(value);
        Expression condition = Expression.Equal(whereProperty, constant);
        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(condition, parameter);
        return source.Where(lambda);
    }
}
