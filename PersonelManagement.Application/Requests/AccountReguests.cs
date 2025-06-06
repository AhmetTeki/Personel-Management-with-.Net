using MediatR;
using PersonelManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Application.Requests
{

    public record LoginRequest(string UserName, string Password, bool rememberMe=false) : IRequest<Result<LoginResponseDto?>>;
    public record RegisterRequest(string UserName, string Password,string Name, string SurName) : IRequest<Result<NoData>>;
}
