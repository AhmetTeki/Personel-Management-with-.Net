using PersonelManagement.Application.Enums;
using PersonelManagement.Application.Requests;
using PersonelManagement.Domain.Entities;

namespace PersonelManagement.Application.Extensions
{
    public static  class MappingExtensions
    {
        public static AppUser ToMap(this RegisterRequest request)
        {
            return new AppUser
            {
                AppRoleId = (int)RoleType.Member,
                Name = request.Name,
                Password = request.Password,
                SurName = request.SurName,
                UserName = request.UserName,
            };
        }
    }
}
