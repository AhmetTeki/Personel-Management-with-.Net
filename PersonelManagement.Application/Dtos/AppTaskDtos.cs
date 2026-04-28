using PersonelManagement.Domain.Entities;

namespace PersonelManagement.Application.Dtos;

public record AppTaskListDto(int Id, string Title, string Description, string? User ,string? PriorityDefination, bool State, int PriorityId);
public record AppTaskDto(List<PriorityListDto> Priorities, List<AppUser>? Employees = null);

