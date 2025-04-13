using Microsoft.EntityFrameworkCore;
using PersonelManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Persistance.Context
{
   public class PersonelManagementContext : DbContext
    {
        public PersonelManagementContext(DbContextOptions<PersonelManagementContext> options):base(options)
        {
            
        }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AppTask> Tasks { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<TaskReport> TaskReports { get; set; }
    }
}
