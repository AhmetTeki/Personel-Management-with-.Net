namespace PersonelManagement.Domain.Entities
{
   public class Priority
    {
        public int Id { get; set; }
        public string Definition { get; set; } = null!;
        public List<AppTask>? Tasks { get; set; } = null!;
    }
}
