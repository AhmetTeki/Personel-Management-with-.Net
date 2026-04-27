using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.Application.Handlers.AppTask;

public class AppTaskDeleteHandler(IAppTaskRepository _appTaskRepository) : IRequestHandler<AppTaskDeleteRequest, Result<NoData>>
{
    public async Task<Result<NoData>> Handle(AppTaskDeleteRequest request, CancellationToken cancellationToken)
    {
        var deletedEntity = await _appTaskRepository.GetFilterAsync(x => x.Id == request.Id);
        await _appTaskRepository.DeleteAsync(deletedEntity);
        return new Result<NoData>(new NoData(), true, null, null);
    }
}