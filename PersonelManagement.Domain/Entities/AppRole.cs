namespace PersonelManagement.Domain.Entities
{
   public class AppRole
    {
        public int Id { get; set; }
        public string Definition { get; set; } = null!;
        public List<AppUser>? Users { get; set; } = null!;
    }
}
