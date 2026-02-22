using FluentValidation.Results;
using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Enums;
using PersonelManagement.Application.Extensions;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;
using PersonelManagement.Application.Validator;
using PersonelManagement.Domain.Entities;


namespace PersonelManagement.Application.Handlers
{
    public class LoginRequestHandler(IUserRepository userRepository) : IRequestHandler<LoginRequest, Result<LoginResponseDto?>>
    {
        public async Task<Result<LoginResponseDto?>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            LoginRequestValidator validator = new LoginRequestValidator();
            ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                AppUser? user =
                    await userRepository.GetByFilterAsync(x => x.Password == request.Password && x.UserName == request.UserName);

                if (user != null)
                {
                    RoleType type = (RoleType)user.AppRoleId;
                    return new Result<LoginResponseDto?>(new LoginResponseDto(user.Name, user.SurName, type), true, null, null);
                }
                else
                {
                    return new Result<LoginResponseDto?>(null, false, "Kullanıcı Adı veya şifre hatalı", null);
                }
            }
            else
            {
                List<ValidationError> errorList = validationResult.Errors.ToMap();
                return new Result<LoginResponseDto?>(null, false, null, errorList);
            }
        }
    }
}