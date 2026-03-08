using MediatR;
using PersonelManagement.Application.Dtos;

namespace PersonelManagement.Application.Requests;

public record AppTaskListRequest() : IRequest<Result<List<AppTaskListDto>>>;