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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customers;

        public CustomerController(ICustomerRepository customers)
        {
            this.customers = customers;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerGeneralInfoDto>>> GetCustomers()
        {
            var allCustomers = await customers.GetAllCustomers();
            return allCustomers.ToList();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetailsDto>> GetCustomer(int id)
        {
            var customer = await customers.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            await customers.UpdateCustomer(customer);

            return NoContent();
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerDetailsDto>> PostCustomer(Customer customer)
        {
            await customers.AddCustomer(customer);

            var newCustomer = customers.GetCustomerById(customer.Id);

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, newCustomer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await customers.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            await customers.DeleteCustomer(id);

            return NoContent();
        }
    }
}
