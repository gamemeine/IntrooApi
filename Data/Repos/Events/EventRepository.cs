using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using IntrooApi.Models;

namespace IntrooApi.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly RepairContext context;
        private readonly IMapper mapper;

        public EventRepository(RepairContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EventGeneralInfoDto>> GetAllEvents()
        {
            var events = await context.Events.ToListAsync();

            return mapper.Map<List<EventGeneralInfoDto>>(events);
        }

        public async Task<EventDetailsDto> GetEventById(int id)
        {
            var _event = await context.Events
                                    .Include(x => x.Repair)
                                    .ThenInclude(x => x.Car)
                                    .Include(x => x.Repair)
                                    .ThenInclude(x => x.Customer)
                                    .FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<EventDetailsDto>(_event);
        }

        public async Task AddEvent(Event _event)
        {
            await context.Events.AddAsync(_event);
            await Save();
        }

        public async Task DeleteEvent(int id)
        {
            var _event = await context.Events.FindAsync(id);

            if (_event is null) return;

            context.Events.Remove(_event);
            await Save();
        }


        public async Task UpdateEvent(Event _event)
        {
            var repair = await context.Repairs.FindAsync(_event.RepairId);

            if (repair != null) _event.Repair = repair;

            context.Entry(_event).State = EntityState.Modified;

            try
            {
                await Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (EventExists(_event))
                {
                    throw;
                }
            }
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        private bool EventExists(Event _event)
        {
            return context.Events.Any(x => x.Id == _event.Id);
        }
    }
}