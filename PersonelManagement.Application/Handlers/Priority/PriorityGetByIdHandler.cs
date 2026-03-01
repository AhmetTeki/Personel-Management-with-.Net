using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.Application.Handlers.Priority;

public class PriorityGetByIdHandler(IPriorityRepository _priorityRepository)
    : IRequestHandler<PriorityGetByIdRequest, Result<PriorityListDto>>
{
    public async Task<Result<PriorityListDto>> Handle(PriorityGetByIdRequest request, CancellationToken cancellationToken)
    {
        var priority = await _priorityRepository.GetFilterNoTrackingAsync(x => x.Id == request.Id);

        if (priority == null)
        {
            return new Result<PriorityListDto>(new PriorityListDto(0, ""), false, "Bir Hata Oluştu", null);
        }
        
        return new Result<PriorityListDto>(new PriorityListDto(priority.Id, priority.Definition), true, null, null);

    }
}