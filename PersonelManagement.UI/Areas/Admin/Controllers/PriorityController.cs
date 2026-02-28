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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PriorityCreateRequest request)
    {
        var result = await _mediator.Send(request);

        if (result.IsSucces)
        {
            return RedirectToAction("List");
        }
        else
        {
            if (result.Errors != null && result.Errors.Count > 0)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            else
            {
                ModelState.AddModelError("", result.ErrorMassage ?? "Bilinmeyen Bir Hata Oluştu");
            }

            return View(request);
        }
    }
}