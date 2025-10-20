using Microsoft.EntityFrameworkCore;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Domain.Entities;
using PersonelManagement.Persistance.Context;
using System.Linq.Expressions;

namespace PersonelManagement.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PersonelManagementContext _context;

        public UserRepository(PersonelManagementContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUserAsync(AppUser user)
        {
            await this._context.AddAsync(user);
            return await this._context.SaveChangesAsync();

        }

        public async Task<AppUser?> GetByFilterAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true)
        {

            if (asNoTracking)
            {
                return await this._context.Users.AsNoTracking().SingleOrDefaultAsync(filter);
            }
            return await this._context.Users.SingleOrDefaultAsync(filter);
        }
    }
}
