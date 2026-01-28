using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleSample.Models
{
    public class EditParams
    {
        public string key { get; set; }  // key value is appointment id value - while deleting the appointment it comes
        public string action { get; set; } // action indicates the current action of the CRUD operation. Ex: while adding new appointment the action value coming as "insert"
        public List<ScheduleEventData> added { get; set; } // added indicates the newly added appointment object details while modifying the recurrence events
        public List<ScheduleEventData> changed { get; set; } // changed indicates the edited/updated appointment object details
        public List<ScheduleEventData> deleted { get; set; } // deleted indicates the deleted appointment object details
        public ScheduleEventData value { get; set; } // value indicates the newly added appointment object details
    }
}