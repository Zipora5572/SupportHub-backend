using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Ticketing.Core.IRepositories;
using Ticketing.Data;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbSet<T> _dbSet;
    private readonly IDataContext _context;

    public Repository(IDataContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await Task.CompletedTask; 
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<T> UpdateAsync(int id, T updatedEntity)
    {
        var existingEntity = await _dbSet.FindAsync(id);
        if (existingEntity == null)
            return null;

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.Name != "Id");

        foreach (var prop in properties)
        {
            var value = prop.GetValue(updatedEntity);
            if (value != null)
                prop.SetValue(existingEntity, value);
        }

        return existingEntity;
    }
}
