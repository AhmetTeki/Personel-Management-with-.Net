using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.Application.Handlers.Priority;

public class PriorityListHandler(IPriorityRepository _priorityRepository)
    : IRequestHandler<PriorityListRequest, Result<List<PriorityListDto>>>
{
    public async Task<Result<List<PriorityListDto>>> Handle(PriorityListRequest request, CancellationToken cancellationToken)
    {
        var result = await _priorityRepository.GetAllAsync();

        List<PriorityListDto> mappedResult = result.Select(x => new PriorityListDto(x.Id, x.Definition)).ToList();

        return new Result<List<PriorityListDto>>(mappedResult, true, null, null);
    }
}