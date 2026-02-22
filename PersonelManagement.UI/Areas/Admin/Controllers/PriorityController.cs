using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.UI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class PriorityController(IMediator _mediator) : Controller
{
    public async Task<IActionResult> List()
    {
        Result<List<PriorityListDto>> result = await _mediator.Send(new PriorityListRequest());
        return View(result.Data);
    }
}