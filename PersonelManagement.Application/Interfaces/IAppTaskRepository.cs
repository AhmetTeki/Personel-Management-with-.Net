using System.Linq.Expressions;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Domain.Entities;

namespace PersonelManagement.Application.Interfaces;

public interface IAppTaskRepository
{
    Task<PagedData<AppTask>> GetAllAsync(int ActivePage, string? s = null, int PageSize = 10);
    Task<int> CreateAsync(AppTask appTask);

    Task<AppTask?> GetFilterNoTrackingAsync(Expression<Func<AppTask, bool>> filter);
    Task<AppTask?> GetFilterAsync(Expression<Func<AppTask, bool>> filter);

    Task DeleteAsync(AppTask appTask);

    Task<int> SaveChangesAsync();
}