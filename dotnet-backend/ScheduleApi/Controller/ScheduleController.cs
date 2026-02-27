using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulerApi.Data;
using SchedulerApi.Models;

namespace SchedulerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ScheduleEventData>>> Get()
        => await db.ScheduleEventDataTable.AsNoTracking().ToListAsync();

    [HttpPost]
    public async Task<ActionResult<ScheduleEventData>> Create([FromBody] ScheduleEventData item)
    {
        db.ScheduleEventDataTable.Add(item);
        await db.SaveChangesAsync();
        return Ok(item);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ScheduleEventData item)
    {
        if (id != item.Id) return BadRequest();
        db.Entry(item).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var found = await db.ScheduleEventDataTable.FindAsync(id);
        if (found is null) return NotFound();
        db.ScheduleEventDataTable.Remove(found);
        await db.SaveChangesAsync();
        return NoContent();
    }
}