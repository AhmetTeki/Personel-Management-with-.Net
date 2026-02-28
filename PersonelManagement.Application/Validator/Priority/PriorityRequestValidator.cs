using FluentValidation;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.Application.Validator.Priority;

public class PriorityRequestValidator : AbstractValidator<PriorityCreateRequest>
{
    public PriorityRequestValidator()
    {
        this.RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım Alanı Boş Bırakılamaz");
    }
}