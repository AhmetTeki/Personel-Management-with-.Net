using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Domain.Entities
{
   public class AppTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int AppUserId { get; set; }
        public int PriorityId { get; set; }
        public bool State { get; set; }
    }
}
