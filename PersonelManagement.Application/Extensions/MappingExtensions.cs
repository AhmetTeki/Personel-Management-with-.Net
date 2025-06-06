using PersonelManagement.Application.Enums;
using PersonelManagement.Application.Requests;
using PersonelManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
