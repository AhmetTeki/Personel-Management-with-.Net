using FluentValidation;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.Application.Validator.AppTask;

public class AppTaskCreateDtoValidator: AbstractValidator<AppTaskCreateRequest>
{
    public AppTaskCreateDtoValidator()
    {
        this.RuleFor(x => x.Title).NotEmpty().WithMessage("Boş geçilemez");
        this.RuleFor(x => x.Description).NotEmpty().WithMessage("Boş geçilemez");
    }
}