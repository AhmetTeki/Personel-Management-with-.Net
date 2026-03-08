using MediatR;
using PersonelManagement.Application.Dtos;

namespace PersonelManagement.Application.Requests;

public record AppTaskListRequest : PagedRequest, IRequest<PagedResult<AppTaskListDto>>
{
    public AppTaskListRequest(int activePage) : base(activePage)
    {
        
    }
}