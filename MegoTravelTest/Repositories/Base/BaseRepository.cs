using Microsoft.EntityFrameworkCore;
using MegoTravelTest.Repositories.Base.AppDbContext;

namespace MegoTravelTest.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    protected BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public IEnumerable<T> Find(Func<T, bool> func)
    {
        return _dbSet.Where(func).ToList();
    }

    public void Create(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
        _context.SaveChanges();
    }
}