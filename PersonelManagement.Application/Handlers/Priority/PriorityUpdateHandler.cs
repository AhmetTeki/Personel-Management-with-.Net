using FluentValidation.Results;
using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Extensions;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;
using PersonelManagement.Application.Validator.Priority;

namespace PersonelManagement.Application.Handlers.Priority;

public class PriorityUpdateHandler(IPriorityRepository _priorityRepository)
    : IRequestHandler<PriorityUpdateRequest, Result<NoData>>
{
    public async Task<Result<NoData>> Handle(PriorityUpdateRequest request, CancellationToken cancellationToken)
    {
        PriorityUpdateRequestValidator validator = new PriorityUpdateRequestValidator();
        ValidationResult? validationResult = validator.Validate(request);

        if (validationResult.IsValid)
        {
            var priority = await _priorityRepository.GetFilterAsync(x => x.Id == request.Id);
            if (priority != null)
            {
                priority.Definition = request.Definition;
                await _priorityRepository.SaveChangesAsync();
                return new Result<NoData>(new NoData(), true, null, null);
            }
            else
            {
                return new Result<NoData>(new NoData(), false, "Bir Hata Oluştu", null);
            }
        }
        else
        {
            List<ValidationError> errorList = validationResult.Errors.ToMap();
            return new Result<NoData>(new NoData(), false, null, errorList);
        }
    }
}