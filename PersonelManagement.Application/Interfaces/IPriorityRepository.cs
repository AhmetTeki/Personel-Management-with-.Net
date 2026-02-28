using PersonelManagement.Domain.Entities;

namespace PersonelManagement.Application.Interfaces;

public interface IPriorityRepository
{
    Task<List<Priority>> GetAllAsync();
    Task<int> CreateAsync(Priority priority);
}