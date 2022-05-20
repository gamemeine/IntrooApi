#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntrooApi.Models;
using IntrooApi.Data;

namespace IntrooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository events;

        public EventController(IEventRepository events)
        {
            this.events = events;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventGeneralInfoDto>>> GetEvents()
        {
            var allEvents = await events.GetAllEvents();
            return allEvents.ToList();
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetailsDto>> GetEvent(int id)
        {
            var _event = await events.GetEventById(id);

            if (_event == null) return NotFound();

            return _event;
        }

        // PUT: api/Event/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event _event)
        {
            if (id != _event.Id) return BadRequest();

            await events.UpdateEvent(_event);
            return NoContent();
        }

        // POST: api/Event
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event _event)
        {
            await events.AddEvent(_event);

            var newEvent = events.GetEventById(_event.Id);
            return CreatedAtAction("GetEvent", new { id = _event.Id }, newEvent);
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var _event = await events.GetEventById(id);
            if (_event == null) return NotFound();

            await events.DeleteEvent(id);
            return NoContent();
        }
    }
}
