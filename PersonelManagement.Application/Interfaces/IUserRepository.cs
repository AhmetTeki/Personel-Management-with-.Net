using PersonelManagement.Domain.Entities;
using System.Linq.Expressions;

namespace PersonelManagement.Application.Interfaces
{
   public interface IUserRepository
    {
        Task<AppUser?> GetByFilterAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true);
        Task<int> CreateUserAsync(AppUser user);
    }
}
