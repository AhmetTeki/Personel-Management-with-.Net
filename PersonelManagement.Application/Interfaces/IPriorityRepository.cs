using System.Linq.Expressions;
using PersonelManagement.Domain.Entities;

namespace PersonelManagement.Application.Interfaces;

public interface IPriorityRepository
{
    Task<List<Priority>> GetAllAsync();
    Task<int> CreateAsync(Priority priority);

    Task<Priority?> GetFilterNoTrackingAsync(Expression<Func<Priority, bool>> filter);
    Task<Priority?> GetFilterAsync(Expression<Func<Priority, bool>> filter);
    
    Task DeleteAsync(Priority priority);
    
    Task<int> SaveChangesAsync();
}