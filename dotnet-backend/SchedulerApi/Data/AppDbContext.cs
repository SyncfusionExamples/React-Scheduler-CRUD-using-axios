using Microsoft.EntityFrameworkCore;
using SchedulerApi.Models;

namespace SchedulerApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ScheduleEventData> ScheduleEventDatas => Set<ScheduleEventData>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var e = modelBuilder.Entity<ScheduleEventData>();
            e.ToTable("ScheduleEventDatas");
            e.Property(x => x.Id)
              .ValueGeneratedNever(); // app provides Id

            // Map to datetimeoffset in SQL Server
            e.Property(x => x.StartTime).HasColumnType("datetimeoffset");
            e.Property(x => x.EndTime).HasColumnType("datetimeoffset");
        }
    }
}