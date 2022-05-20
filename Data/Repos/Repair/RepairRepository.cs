using AutoMapper;
using IntrooApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IntrooApi.Data
{
    public class RepairRepository : IRepairRepository
    {
        private readonly RepairContext context;
        private readonly IMapper mapper;

        public RepairRepository(RepairContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RepairGeneralInfoDto>> GetAllRepairs()
        {
            var repairs = await context.Repairs
                            .Include(repair => repair.Customer)
                            .Include(repair => repair.Car)
                            .ToListAsync();

            return mapper.Map<List<RepairGeneralInfoDto>>(repairs);
        }

        public async Task<RepairDetailsDto> GetRepairById(int id)
        {
            var repair = await context.Repairs
                                    .Include(x => x.Car)
                                    .Include(x => x.Customer)
                                    .Include(x => x.Events)
                                    .FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<RepairDetailsDto>(repair);
        }

        public async Task AddRepair(Repair repair)
        {
            await context.Repairs.AddAsync(repair);
            await Save();
        }

        public async Task DeleteRepair(int id)
        {
            var repair = await context.Repairs
                                .Include(x => x.Events)
                                .FirstOrDefaultAsync(x => x.Id == id);

            if (repair == null) return;

            foreach (var e in repair.Events)
            {
                context.Events.Remove(e);
            }

            context.Repairs.Remove(repair);
            await Save();
        }

        public async Task UpdateRepair(Repair repair)
        {
            var car = await context.Cars.FindAsync(repair.CarId);
            var customer = await context.Customers.FindAsync(repair.CustomerId);
            var events = await context.Events.Where(x => x.RepairId == repair.Id).ToListAsync();

            if (car is not null) repair.Car = car;
            if (customer is not null) repair.Customer = customer;
            if (events is not null) repair.Events = events;

            context.Entry(repair).State = EntityState.Modified;

            try
            {
                await Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (RepairExists(repair.Id))
                {
                    throw;
                }
            }

        }
        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        private bool RepairExists(int id)
        {
            return context.Repairs.Any(e => e.Id == id);
        }
    }
}