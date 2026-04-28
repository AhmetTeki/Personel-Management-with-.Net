using PersonelManagement.Application.Dtos;
using PersonelManagement.Application.Enums;
using PersonelManagement.Application.Requests;
using PersonelManagement.Domain.Entities;

namespace PersonelManagement.Application.Extensions
{
    public static class MappingExtensions
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

        public static Priority ToMap(this PriorityCreateRequest request)
        {
            return new Priority
            {
                Definition = request.Definition,
            };
        }

        public static AppTask ToMap(this AppTaskCreateRequest request)
        {
            return new AppTask
            {
                Description = request.Description,
                Title = request.Title,
                PriorityId = (int)request.PriorityId,
                State = false
            };
        }

        public static AppTaskListDto ToMap(this AppTask request)
        {
            return new AppTaskListDto(request.Id, request.Title, request.Description, request.AppUser.Name, request.Priority.Definition,
                request.State, request.PriorityId);
        }
    }
}