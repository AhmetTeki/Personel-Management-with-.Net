using MediatR;
using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Extensions;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Application.Requests;
using PersonelManagement.Application.Validator;

namespace PersonelManagement.Application.Handlers
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, Result<NoData>>
    {
        private readonly IUserRepository _userRepository;

        public RegisterRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<NoData>> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var validator = new RegisterRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var rowCount = await _userRepository.CreateUserAsync(request.ToMap());
                if (rowCount > 0)
                {
                    return new Result<NoData>(new NoData(), true, null, null);
                }
                else
                {
                    return new Result<NoData>(new NoData(), false, "Bir hata oluştu", null);
                }
            }
            else
            {
                var errorList=validationResult.Errors.ToMap();
                return new Result<NoData>(new NoData(), false, null, errorList);
            }

        }
    }
}
