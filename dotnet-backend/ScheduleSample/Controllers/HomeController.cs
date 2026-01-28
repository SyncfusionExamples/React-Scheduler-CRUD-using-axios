using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScheduleSample.Models;
using Syncfusion.EJ2.Schedule;
using Syncfusion.EJ2.Popups;

namespace ScheduleSample.Controllers
{
    public class HomeController : Controller
    {
        ScheduleDataDataContext db = new ScheduleDataDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()  // Here we return data to Schedulerl
        {
            var data = db.ScheduleEventDatas.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Insert(ScheduleEventData insertData)
        {
            var value = insertData;
            int intMax = db.ScheduleEventDatas.ToList().Count > 0 ? db.ScheduleEventDatas.ToList().Max(p => p.Id) : 1;
            DateTime startTime = Convert.ToDateTime(value.StartTime);
            DateTime endTime = Convert.ToDateTime(value.EndTime);
            ScheduleEventData appointment = new ScheduleEventData()
            {
                Id = intMax + 1,
                StartTime = startTime.ToLocalTime(),
                EndTime = endTime.ToLocalTime(),
                Subject = value.Subject,
                IsAllDay = value.IsAllDay,
                StartTimezone = value.StartTimezone,
                AirlineId = value.AirlineId,
                PilotId = value.PilotId,
                EndTimezone = value.EndTimezone,
                RecurrenceRule = value.RecurrenceRule,
                RecurrenceID = value.RecurrenceID,
                RecurrenceException = value.RecurrenceException,
            };
            db.ScheduleEventDatas.InsertOnSubmit(appointment);
            db.SubmitChanges();
            var data = GetData();
            return data;
        }

        public JsonResult Update(ScheduleEventData updateData)
        {
            var value = updateData;
            var filterData = db.ScheduleEventDatas.Where(c => c.Id == Convert.ToInt32(value.Id));
            if (filterData.Count() > 0)
            {
                DateTime startTime = Convert.ToDateTime(value.StartTime);
                DateTime endTime = Convert.ToDateTime(value.EndTime);
                ScheduleEventData appointment = db.ScheduleEventDatas.Single(A => A.Id == Convert.ToInt32(value.Id));
                appointment.StartTime = startTime.ToLocalTime();
                appointment.EndTime = endTime.ToLocalTime();
                appointment.StartTimezone = value.StartTimezone;
                appointment.EndTimezone = value.EndTimezone;
                appointment.Subject = value.Subject;
                appointment.IsAllDay = value.IsAllDay;
                appointment.AirlineId = value.AirlineId;
                appointment.PilotId = value.PilotId;
                appointment.RecurrenceRule = value.RecurrenceRule;
                appointment.RecurrenceID = value.RecurrenceID;
                appointment.RecurrenceException = value.RecurrenceException;
            }
            db.SubmitChanges();
            var data = GetData();
            return data;
        }
        public JsonResult Delete(ScheduleEventData deleteData)
        {
            var value = deleteData;
            ScheduleEventData appointment = db.ScheduleEventDatas.Where(c => c.Id == value.Id).FirstOrDefault();
            if (appointment != null) db.ScheduleEventDatas.DeleteOnSubmit(appointment);
            db.SubmitChanges();
            var data = GetData();
            return data;
        }
      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
    public class request
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
    public class CrudData
    {

        public int Id { get; set; }

        public string Subject { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string StartTimezone { get; set; }

        public string EndTimezone { get; set; }

        public bool IsAllDay { get; set; }

        public string RecurrenceRule { get; set; }

        public int RecurrenceID { get; set; }

        public string RecurrenceException { get; set; }

    }
}