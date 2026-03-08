using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.Application.Handlers.AppTask;

public class AppTaskListHandler(IAppTaskRepository _appTaskRepository) : IRequestHandler<AppTaskListRequest, Result<List<AppTaskListDto>>>
{
    public async Task<Result<List<AppTaskListDto>>> Handle(AppTaskListRequest request, CancellationToken cancellationToken)
    {
        var list = await _appTaskRepository.GetAllAsync();

        var result = new List<AppTaskListDto>();

        foreach (var item in list)
        {
            var dto = new AppTaskListDto(item.Id, item.Title, item.Description, item.AppUser?.Name, item.Priority?.Definition, item.State);
            result.Add(dto);
        }

        return new Result<List<AppTaskListDto>>(result, true, null, null);
    }
}