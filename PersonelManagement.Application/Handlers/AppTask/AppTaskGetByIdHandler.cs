using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Extensions;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.Application.Handlers.AppTask;

public class AppTaskGetByIdHandler(IAppTaskRepository _appTaskRepository) : IRequestHandler<AppTaskGetByIdRequest, Result<AppTaskListDto>>
{
    public async Task<Result<AppTaskListDto>> Handle(AppTaskGetByIdRequest request, CancellationToken cancellationToken)
    {
        var task = await _appTaskRepository.GetFilterNoTrackingAsync(x => x.Id == request.Id);

        
        return new Result<AppTaskListDto>(task.ToMap(), true, null, null);
    }
}