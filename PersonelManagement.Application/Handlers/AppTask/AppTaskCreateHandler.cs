using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Extensions;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;
using PersonelManagement.Application.Validator.AppTask;

namespace PersonelManagement.Application.Handlers.AppTask;

public class AppTaskCreateHandler : IRequestHandler<AppTaskCreateRequest, Result<NoData>>
{
    private readonly IAppTaskRepository _appTaskRepository;

    public AppTaskCreateHandler(IAppTaskRepository appTaskRepository)
    {
        _appTaskRepository = appTaskRepository;
    }

    public async Task<Result<NoData>> Handle(AppTaskCreateRequest request, CancellationToken cancellationToken)
    {
        var validator = new AppTaskCreateDtoValidator();
        var validationResult = validator.Validate(request);

        if (validationResult.IsValid)
        {
            await _appTaskRepository.CreateAsync(request.ToMap());
            return new Result<NoData>(new NoData(), true, null, null);
        }
        else
        {
            return new Result<NoData>(new NoData(), false, null, validationResult.Errors.ToMap());
        }
    }
}