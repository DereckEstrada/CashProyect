using System.Linq.Expressions;
using Cash.BE.Dtos;
using Cash.BE.Querying;

namespace Cash.DAC.Interfaces;

public interface IRepository<T>
{
    Task<T?> FindByIdAsync(int id);
    Task<int> CountAsync(QueryOptions<T> options);
    IQueryable<T> GetIQueryable(QueryOptions<T> options);
    Task<T> AddAsync(T entity);
    void Update(T entity);
    Task<int> SaveChangesAsync();
}