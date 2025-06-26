using Cash.BE.Helpers;
using Cash.BE.Querying;
using Microsoft.EntityFrameworkCore;

namespace Cash.BE.Extensions;

public static class IQueryableExtension
{
    public static IQueryable<T> GenerateIQueryable<T>(this IQueryable<T> query,  QueryOptions<T>? queryOptions)where T : class
    {
        if (queryOptions is null) return query;
        
        query.GetWhereIQueryable(queryOptions); 
        
        if (queryOptions.OrderBy is not null)
        {
            query = queryOptions.OrderByDescending ?query.OrderByDescending(queryOptions.OrderBy):  query.OrderBy(queryOptions.OrderBy);
            if (queryOptions.Pagination is not null)
                query = query.Skip(queryOptions.Pagination.Page).Take(queryOptions.Pagination.PageSize);
        }else if (queryOptions.Pagination is not null)
        {
            throw new InvalidOperationException(ErrorMessage.PaginationWithOutOrder);
        }

        if (queryOptions.Includes is not null)
            foreach (var queryOptionsInclude in queryOptions.Includes)
            {
                query = query.Include(queryOptionsInclude);
            }
        
        return query;
    }

    public static IQueryable<T> GetWhereIQueryable<T>(this IQueryable<T> query, QueryOptions<T>? options)
    {
        if (options is null) return query;
        
        if(options.Where is not null) query = query.Where(options.Where);
        
        return query;
    }
}