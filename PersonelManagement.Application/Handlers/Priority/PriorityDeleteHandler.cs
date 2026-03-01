using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.Application.Handlers.Priority;

public class PriorityDeleteHandler(IPriorityRepository _priorityRepository)
    : IRequestHandler<PriorityDeleteRequest, Result<NoData>>
{
    public async Task<Result<NoData>> Handle(PriorityDeleteRequest request, CancellationToken cancellationToken)
    {
        var deletedEntity = await _priorityRepository.GetFilterAsync(x => x.Id == request.Id);

        if (deletedEntity != null)
        {
            await _priorityRepository.DeleteAsync(deletedEntity);
            return new Result<NoData>(new NoData(), true, null, null);
        }

        return new Result<NoData>(new NoData(), false, "Bir Hata Oluştu", null);
    }
}