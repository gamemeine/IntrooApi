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
    public class RepairController : ControllerBase
    {
        private readonly RepairContext _context;
        private IRepairRepository repairs;

        public RepairController(IRepairRepository repairs, RepairContext context)
        {
            this._context = context;
            this.repairs = repairs;
        }

        // GET: api/Repair
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairGeneralInfoDto>>> GetRepairs()
        {
            var allRepairs = await repairs.GetAllRepairs();
            return allRepairs.ToList();
        }

        // GET: api/Repair/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairDetailsDto>> GetRepair(int id)
        {
            var repair = await repairs.GetRepairById(id);

            if (repair == null)
            {
                return NotFound();
            }

            return repair;
        }

        // PUT: api/Repair/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepair(int id, Repair repair)
        {
            if (id != repair.Id)
            {
                return BadRequest();
            }

            await repairs.UpdateRepair(repair);

            return NoContent();
        }

        // POST: api/Repair
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Repair>> PostRepair(Repair repair)
        {
            await repairs.AddRepair(repair);

            var repairDetails = await repairs.GetRepairById(repair.Id);
            return CreatedAtAction("GetRepair", new { id = repair.Id }, repairDetails);
        }

        // DELETE: api/Repair/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepair(int id)
        {
            var repair = await repairs.GetRepairById(id);
            if (repair == null)
            {
                return NotFound();
            }

            await repairs.DeleteRepair(id);

            return NoContent();
        }
    }
}
