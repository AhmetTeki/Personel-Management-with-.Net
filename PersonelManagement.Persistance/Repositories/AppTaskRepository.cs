using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Domain.Entities;
using PersonelManagement.Persistance.Context;

namespace PersonelManagement.Persistance.Repositories;

public class AppTaskRepository(PersonelManagementContext _context) : IAppTaskRepository
{
    public async Task<List<AppTask>> GetAllAsync()
    {
        return await _context.Tasks.AsNoTracking().Include(x => x.AppUser).Include(x => x.Priority).ToListAsync();
    }

    public async Task<int> CreateAsync(AppTask appTask)
    {
        throw new NotImplementedException();
    }

    public async Task<AppTask?> GetFilterNoTrackingAsync(Expression<Func<AppTask, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<AppTask?> GetFilterAsync(Expression<Func<AppTask, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(AppTask appTask)
    {
        throw new NotImplementedException();
    }

    public async Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}