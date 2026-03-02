using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulerApi.Models;

[Table("ScheduleEventDataTable")]
public class ScheduleEventData
{
    public int Id { get; set; }
    public string? Subject { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public string? StartTimezone { get; set; }
    public string? EndTimezone { get; set; }
    public bool IsAllDay { get; set; }
    public string? RecurrenceRule { get; set; }
    public int? RecurrenceID { get; set; }
    public string? RecurrenceException { get; set; }
}