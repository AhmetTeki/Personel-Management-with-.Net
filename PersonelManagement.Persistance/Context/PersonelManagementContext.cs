using Microsoft.EntityFrameworkCore;
using PersonelManagement.Domain.Entities;
using PersonelManagement.Persistance.Configurations;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppTaskConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new PriorityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskReportConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AppTask> Tasks { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<TaskReport> TaskReports { get; set; }
    }
}
