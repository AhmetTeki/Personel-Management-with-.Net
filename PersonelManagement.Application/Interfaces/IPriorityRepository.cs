using PersonelManagement.Application.Dtos;
using PersonelManagement.Domain.Entities;

namespace PersonelManagement.Application.Interfaces;

public interface IPriorityRepository
{
    Task<List<Priority>> GetAllAsync();
}