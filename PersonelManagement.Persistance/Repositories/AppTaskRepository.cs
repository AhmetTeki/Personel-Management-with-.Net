using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Domain.Entities;
using PersonelManagement.Persistance.Context;
using PersonelManagement.Persistance.Extensions;

namespace PersonelManagement.Persistance.Repositories;

public class AppTaskRepository(PersonelManagementContext _context) : IAppTaskRepository
{
    public async Task<PagedData<AppTask>> GetAllAsync(int ActivePage, string? s = null, int PageSize = 10)
    {
        var query = _context.Tasks.AsQueryable();
        if (!string.IsNullOrEmpty(s))
        {
            query = query.Where(x => x.Title.ToLower().Contains(s) || x.Description.ToLower().Contains(s));
        }

        var list = await query.AsNoTracking().Include(x => x.AppUser).Include(x => x.Priority)
            .ToPagedAsync(ActivePage, PageSize);
        return list;
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