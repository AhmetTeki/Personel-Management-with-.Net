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
        public string Description { get; set; } = null!;
        public int AppUserId { get; set; }   
        public int PriorityId { get; set; }
        public bool State { get; set; }
        public AppUser? AppUser { get; set; }
        public Priority? Priority { get; set; }
        public List<TaskReport>? TaskReports { get; set; }
    }
}
