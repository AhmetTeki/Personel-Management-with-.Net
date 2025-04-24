using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Extensions;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;
using PersonelManagement.Application.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Application.Handlers
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, Result<LoginResponseDto?>>
    {
        private readonly IUserRepository _userRepository;

        public LoginRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<LoginResponseDto?>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
          var validator=  new LoginRequestValidator();
          var validationResult= await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
              var user=await  this._userRepository.GetByFilter(x=>x.Password==request.Password && x.UserName==request.UserName);
                if (user != null)
                {
                    return new Result<LoginResponseDto?>(new LoginResponseDto(user.Name,user.SurName,user.AppRoleId), true, null, null);
                }
                else
                {
                    return new Result<LoginResponseDto?>(null, false, "Kullanıcı Adı veya şifre hatalı", null);
                }
                
            }
            else
            {
                var errorList = validationResult.Errors.ToMap();
                return new Result<LoginResponseDto?>(null, false, null, errorList);
            }
           
        }
    }
}
