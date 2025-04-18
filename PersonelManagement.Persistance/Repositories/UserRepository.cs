using Microsoft.EntityFrameworkCore;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Domain.Entities;
using PersonelManagement.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Persistance.Repositories
{
   public class UserRepository : IUserRepository
    {
        private readonly PersonelManagementContext _context;

        public UserRepository(PersonelManagementContext context)
        {
            _context = context;
        }

        public async Task<AppUser?> GetByFilter(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true)
        {

            if (asNoTracking)
            {
                return await this._context.Users.AsNoTracking().SingleOrDefaultAsync(filter);
            }
            return await this._context.Users.SingleOrDefaultAsync(filter);
        }
    }
}
