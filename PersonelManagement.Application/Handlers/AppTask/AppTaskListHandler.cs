using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.Application.Handlers.AppTask;

public class AppTaskListHandler(IAppTaskRepository _appTaskRepository) : IRequestHandler<AppTaskListRequest, PagedResult<AppTaskListDto>>
{
    public async Task<PagedResult<AppTaskListDto>> Handle(AppTaskListRequest request, CancellationToken cancellationToken)
    {
        var list = await _appTaskRepository.GetAllAsync(request.ActivePage);

        var result = new List<AppTaskListDto>();

        foreach (var item in list.Data)
        {
            var dto = new AppTaskListDto(item.Id, item.Title, item.Description, item.AppUser?.Name, item.Priority?.Definition, item.State);
            result.Add(dto);
        }

        return new PagedResult<AppTaskListDto>(result, request.ActivePage, list.PageSize, list.TotalPages);
    }
}