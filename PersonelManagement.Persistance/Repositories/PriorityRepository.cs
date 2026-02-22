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
}