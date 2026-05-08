using Microsoft.EntityFrameworkCore;
using task1.Context;

namespace task1.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public List<T> GetAll()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        SaveChanges();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}