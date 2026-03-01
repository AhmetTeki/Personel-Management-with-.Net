using FluentValidation;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.Application.Validator.Priority;

public class PriorityUpdateRequestValidator : AbstractValidator<PriorityUpdateRequest>
{
    public PriorityUpdateRequestValidator()
    {
        this.RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım Alanı Boş Bırakılamaz");
    }
}