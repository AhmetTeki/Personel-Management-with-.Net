using System.Linq.Expressions;
using PersonelManagement.Domain.Entities;

namespace PersonelManagement.Application.Interfaces;

public interface IAppTaskRepository
{
    Task<List<AppTask>> GetAllAsync();
    Task<int> CreateAsync(AppTask appTask);

    Task<AppTask?> GetFilterNoTrackingAsync(Expression<Func<AppTask, bool>> filter);
    Task<AppTask?> GetFilterAsync(Expression<Func<AppTask, bool>> filter);

    Task DeleteAsync(AppTask appTask);

    Task<int> SaveChangesAsync();
}