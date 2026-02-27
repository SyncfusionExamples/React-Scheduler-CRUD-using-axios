using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulerApi.Models
{
    [Table("ScheduleEventDatas")]
    public class ScheduleEventData
    {
        public int Id { get; set; }

        public string? Subject { get; set; }

        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }

        // Optional timezone labels (not used by EF for conversion)
        public string? StartTimezone { get; set; }
        public string? EndTimezone { get; set; }

        public bool IsAllDay { get; set; }

        // Recurrence related
        public string? RecurrenceRule { get; set; }
        public int? RecurrenceID { get; set; }
        public string? RecurrenceException { get; set; }
    }
}