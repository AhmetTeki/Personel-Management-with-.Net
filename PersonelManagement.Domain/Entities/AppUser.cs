namespace PersonelManagement.Domain.Entities
{
   public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public int AppRoleId { get; set; } 
        public AppRole? Role { get; set; }
        public List<AppTask>? Tasks { get; set; }
        public List<Notification>? Notifications { get; set; }
    }
}
