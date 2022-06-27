#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntrooApi.Services;
using IntrooApi.Models;
using IntrooApi.Data;
using AutoMapper;

namespace IntrooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;
        private readonly IFileStoreService fileStoreService;
        private readonly IStoreFileRepository storeFileRepository;
        private readonly IMapper mapper;

        public EventController(IEventRepository events, IMapper mapper, IFileStoreService fileStore, IStoreFileRepository storeFileRepository)
        {
            this.eventRepository = events;
            this.mapper = mapper;
            this.fileStoreService = fileStore;
            this.storeFileRepository = storeFileRepository;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventGeneralInfoDto>>> GetEvents()
        {
            var allEvents = await eventRepository.GetAllEvents();
            return allEvents.ToList();
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetailsDto>> GetEvent(int id)
        {
            var _event = await eventRepository.GetEventById(id);

            if (_event == null) return NotFound();

            return _event;
        }

        // PUT: api/Event/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, EventPutDto editedEvent)
        {
            if (id != editedEvent.Id) return BadRequest();

            var newEvent = mapper.Map<Event>(editedEvent);

            if (editedEvent.PhotosIds is not null)
            {
                foreach (var photoId in editedEvent?.PhotosIds!)
                {
                    var photoStoreFile = await storeFileRepository.GetStoreFileById(photoId);
                    if (photoStoreFile is null) return BadRequest($"Photo with id {photoId} not found");
                    newEvent.Photos.Add(photoStoreFile);
                }
            }


            await eventRepository.UpdateEvent(newEvent);
            return NoContent();
        }

        // POST: api/Event
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventDetailsDto>> PostEvent(EventPostDto uploadedEvent)
        {
            var newEvent = mapper.Map<Event>(uploadedEvent);

            foreach (var photoId in uploadedEvent.PhotosIds!)
            {
                var photoStoreFile = await storeFileRepository.GetStoreFileById(photoId);
                if (photoStoreFile is null) return BadRequest($"Photo with id {photoId} not found");
                newEvent.Photos.Add(photoStoreFile);
            }

            await eventRepository.AddEvent(newEvent);

            var addedEvent = eventRepository.GetEventById(newEvent.Id);
            return CreatedAtAction("GetEvent", new { id = newEvent.Id }, addedEvent);
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var _event = await eventRepository.GetEventById(id);
            if (_event == null) return NotFound();

            await eventRepository.DeleteEvent(id);
            return NoContent();
        }
    }
}
