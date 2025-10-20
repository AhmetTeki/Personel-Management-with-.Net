using MediatR;
using PersonelManagement.Application.Dtos;

namespace PersonelManagement.Application.Requests
{

    public record LoginRequest(string UserName, string Password, bool rememberMe=false) : IRequest<Result<LoginResponseDto?>>;
    public record RegisterRequest(string UserName, string Password,string ConfirmPassword,string Name, string SurName) : IRequest<Result<NoData>>;
}
