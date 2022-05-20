using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using IntrooApi.Models;

namespace IntrooApi.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RepairContext context;
        private readonly IMapper mapper;

        public CustomerRepository(RepairContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CustomerGeneralInfoDto>> GetAllCustomers()
        {
            var customers = await context.Customers.ToListAsync();
            return mapper.Map<List<CustomerGeneralInfoDto>>(customers);
        }

        public async Task<CustomerDetailsDto> GetCustomerById(int id)
        {
            var customer = await context.Customers
                                        .Include(x => x.Repairs)
                                        .ThenInclude(x => x.Car)
                                        .FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<CustomerDetailsDto>(customer);
        }
        public async Task AddCustomer(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            await Save();
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await context.Customers.FindAsync(id);

            if (customer is null) return;

            context.Customers.Remove(customer);
            await Save();
        }



        public async Task UpdateCustomer(Customer customer)
        {
            var repairs = await context.Repairs.Where(x => x.CustomerId == customer.Id).ToListAsync();

            if (repairs is not null) customer.Repairs = repairs;

            context.Entry(customer).State = EntityState.Modified;

            try
            {
                await Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (CustomerExists(customer))
                {
                    throw;
                }
            }
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        private bool CustomerExists(Customer customer)
        {
            return context.Customers.Any(x => x.Id == customer.Id);
        }
    }



}
