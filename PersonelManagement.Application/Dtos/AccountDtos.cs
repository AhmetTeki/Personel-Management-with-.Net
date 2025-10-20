using PersonelManagement.Application.Enums;

namespace PersonelManagement.Application.Dtos
{

    public record LoginResponseDto(string Name, string Surname, RoleType Role);


}
