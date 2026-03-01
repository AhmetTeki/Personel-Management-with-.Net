using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Domain.Entities;
using PersonelManagement.Persistance.Context;

namespace PersonelManagement.Persistance.Repositories;

public class PriorityRepository(PersonelManagementContext _context) : IPriorityRepository
{
    public async Task<List<Priority>> GetAllAsync()
    {
        return await _context.Priorities.AsNoTracking().ToListAsync();
    }

    public async Task<int> CreateAsync(Priority priority)
    {
        _context.Add(priority);
        return await _context.SaveChangesAsync();
    }

    public async Task<Priority?> GetFilterNoTrackingAsync(Expression<Func<Priority, bool>> filter)
    {
        return await _context.Priorities.AsNoTracking().SingleOrDefaultAsync(filter);
    }

    public async Task<Priority?> GetFilterAsync(Expression<Func<Priority, bool>> filter)
    {
        return await _context.Priorities.SingleOrDefaultAsync(filter);
    }

    public async Task DeleteAsync(Priority priority)
    {
        _context.Priorities.Remove(priority);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}