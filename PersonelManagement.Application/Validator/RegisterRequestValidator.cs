using FluentValidation;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.Application.Validator
{
    public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            this.RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez");
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez");
            this.RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyad boş geçilemez");
            this.RuleFor(x=>x.Password).Equal(x=>x.ConfirmPassword).WithMessage("Şifreler birbiri ile uyuşmuyor");
        }
    }
}
