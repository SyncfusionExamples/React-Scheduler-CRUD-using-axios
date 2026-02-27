using Microsoft.EntityFrameworkCore;
using SchedulerApi.Models;

namespace SchedulerApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ScheduleEventData> ScheduleEventDataTable => Set<ScheduleEventData>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var e = modelBuilder.Entity<ScheduleEventData>();
        e.ToTable("ScheduleEventDataTable");
        e.Property(x => x.Id).ValueGeneratedNever(); // client supplies Id
        e.Property(x => x.StartTime).HasColumnType("datetimeoffset");
        e.Property(x => x.EndTime).HasColumnType("datetimeoffset");
    }
}