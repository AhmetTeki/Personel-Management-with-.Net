using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.UI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AppTaskController(IMediator _mediator) : Controller
{
    public async Task<IActionResult> List(string? s, int activePage = 1)
    {
        var result = await _mediator.Send(new AppTaskListRequest(activePage, s));
        return View(result);
    }

    public async Task<IActionResult> Create()
    {
        var result = await _mediator.Send(new PriorityListRequest());
        ViewBag.Priorities = new List<SelectListItem>(result.Data.Select(x => new SelectListItem(x.Definition, x.Id.ToString())));
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AppTaskCreateRequest request)
    {
        var priority = await _mediator.Send(new PriorityListRequest());
        ViewBag.Priorities = new List<SelectListItem>(priority.Data.Select(x => new SelectListItem(x.Definition, x.Id.ToString())));

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

    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new AppTaskDeleteRequest(id));
        return RedirectToAction("List");
    }

    public async Task<IActionResult> Update(int id)
    {
        var uptadedto = await _mediator.Send(new AppTaskGetByIdRequest(id));

        var result = await _mediator.Send(new PriorityListRequest());
        ViewBag.Priorities =
            new List<SelectListItem>(result.Data.Select(x =>
                new SelectListItem(x.Definition, x.Id.ToString(), uptadedto.Data.PriorityId == x.Id)));

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(PriorityUpdateRequest request)
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