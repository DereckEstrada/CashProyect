using System.Linq.Expressions;
using Cash.BE.Dtos;
using Cash.BE.Extensions;
using Cash.BE.Models;
using Cash.BE.Querying;
using Cash.DAC.Attributes;
using Cash.DAC.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cash.DAC.Repositories;
[Repository]
public class Repository<T>(CashDbContext context) : IRepository<T>
    where T : class
{
    private readonly CashDbContext _context = context;
    private readonly DbSet<T> _entity = context.Set<T>();

    public async Task<T?> FindByIdAsync(int id)
    {
        return await _entity.FindAsync(id);
    }

    public async Task<int> CountAsync(QueryOptions<T> options)
    {
        return await _entity.GetWhereIQueryable(options).CountAsync();
    }
    public  IQueryable<T> GetIQueryable(QueryOptions<T> options)
    {
        return _entity.GenerateIQueryable(options);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _entity.AddAsync(entity);
        return entity;
    }

    public void  Update(T entity)
    {
        _entity.Update(entity);   
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

}