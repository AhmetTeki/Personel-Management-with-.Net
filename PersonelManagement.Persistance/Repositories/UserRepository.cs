using Microsoft.EntityFrameworkCore;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Domain.Entities;
using PersonelManagement.Persistance.Context;
using System.Linq.Expressions;

namespace PersonelManagement.Persistance.Repositories
{
    public class UserRepository(PersonelManagementContext context) : IUserRepository
    {
        public async Task<int> CreateUserAsync(AppUser user)
        {
            await context.AddAsync(user);
            return await context.SaveChangesAsync();
        }

        public async Task<AppUser?> GetByFilterAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await context.Users.AsNoTracking().SingleOrDefaultAsync(filter);
            }

            return await context.Users.SingleOrDefaultAsync(filter);
        }
    }
}