using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Extensions;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;
using PersonelManagement.Application.Validator.Priority;

namespace PersonelManagement.Application.Handlers.Priority;

public class PriorityCreateHandler(IPriorityRepository _priorityRepository)
    : IRequestHandler<PriorityCreateRequest, Result<NoData>>
{
    public async Task<Result<NoData>> Handle(PriorityCreateRequest request, CancellationToken cancellationToken)
    {
        var validator = new PriorityRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var rowCount = await _priorityRepository.CreateAsync(request.ToMap());
            if (rowCount > 0)
            {
                return new Result<NoData>(new NoData(), true, null, null);
            }

            return new Result<NoData>(new NoData(), false, "Bir Hata Oluştu", null);
        }
        else
        {
            List<ValidationError> errorList = validationResult.Errors.ToMap();
            return new Result<NoData>(new NoData(), false, null, errorList);
        }
    }
}