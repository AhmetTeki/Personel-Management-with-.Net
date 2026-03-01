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

    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new PriorityDeleteRequest(id));
        return RedirectToAction("List");
    }

    public async Task<IActionResult> Update(int id)
    {
        var result = await _mediator.Send(new PriorityGetByIdRequest(id));
        if (result.IsSucces)
        {
            var requestModel = new PriorityUpdateRequest(result.Data.Id, result.Data.Definition);
            return View(requestModel);
        }
        else
        {
            ModelState.AddModelError("", result.ErrorMassage ?? "Bilinmeyen Bir Hata Oluştu");
            return View();
        }
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