using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SchedulerApi.Data;
using SchedulerApi.Models;

namespace SchedulerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ScheduleController(AppDbContext db) => _db = db;

        [HttpGet("GetData")]
        public async Task<IActionResult> GetData()
        {
            var data = await _db.ScheduleEventDatas
                                .ToListAsync();
            return Ok(data);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] ScheduleEventData insertData)
        {
            _db.ScheduleEventDatas.Add(insertData);
            await _db.SaveChangesAsync();

            return await GetData();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ScheduleEventData updateData)
        {
            var existing = await _db.ScheduleEventDatas.FirstOrDefaultAsync(e => e.Id == updateData.Id);
            if (existing == null) return NotFound();

            existing.Subject = updateData.Subject;
            existing.IsAllDay = updateData.IsAllDay;
            existing.StartTimezone = updateData.StartTimezone;
            existing.EndTimezone = updateData.EndTimezone;
            existing.RecurrenceRule = updateData.RecurrenceRule;
            existing.RecurrenceID = updateData.RecurrenceID;
            existing.RecurrenceException = updateData.RecurrenceException;

            existing.StartTime = updateData.StartTime;
            existing.EndTime = updateData.EndTime;

            await _db.SaveChangesAsync();
            return await GetData();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] ScheduleEventData deleteData)
        {
            var existing = await _db.ScheduleEventDatas.FirstOrDefaultAsync(e => e.Id == deleteData.Id);

            if (existing != null)
            {
                _db.ScheduleEventDatas.Remove(existing);
                await _db.SaveChangesAsync();
            }

            return await GetData();
        }
    }
}