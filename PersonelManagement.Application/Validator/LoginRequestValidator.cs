using FluentValidation;
using PersonelManagement.Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Application.Validator
{
   public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            this.RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez");
        }
    }
}
