using System.Linq.Expressions;
using Cash.BE.Dtos;

namespace Cash.BE.Querying;

public class QueryOptions<T>
{
    public Expression<Func<T, bool>>? Where { get; set; }
    public Expression<Func<T, object>>? OrderBy { get; set; }
    public bool OrderByDescending { get; set; }
    public Expression<Func<T, object>>[]? Includes { get; set; }
    public PaginationDto? Pagination { get; set; }
}