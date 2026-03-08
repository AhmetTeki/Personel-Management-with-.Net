namespace PersonelManagement.Application.Dtos;

public record AppTaskListDto(int Id, string Title, string Description, string? User ,string? PriorityDefination, bool State);