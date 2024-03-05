using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial2_AP1_MiguelBetances.Api.DAL;
using Parcial2_AP1_MiguelBetances.Shared.Models;

namespace Parcial2_AP1_MiguelBetances.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosDetallesController : ControllerBase
    {
        private readonly Contexto _context;

        public VehiculosDetallesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/VehiculosDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculosDetalle>>> GetVehiculosDetalle()
        {
            return await _context.VehiculosDetalle.ToListAsync();
        }

        // GET: api/VehiculosDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculosDetalle>> GetVehiculosDetalle(int id)
        {
            var vehiculosDetalle = await _context.VehiculosDetalle.FindAsync(id);

            if (vehiculosDetalle == null)
            {
                return NotFound();
            }

            return vehiculosDetalle;
        }

        // PUT: api/VehiculosDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculosDetalle(int id, VehiculosDetalle vehiculosDetalle)
        {
            if (id != vehiculosDetalle.DetalleId)
            {
                return BadRequest();
            }

            _context.Entry(vehiculosDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculosDetalleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VehiculosDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehiculosDetalle>> PostVehiculosDetalle(VehiculosDetalle vehiculosDetalle)
        {
            _context.VehiculosDetalle.Add(vehiculosDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculosDetalle", new { id = vehiculosDetalle.DetalleId }, vehiculosDetalle);
        }

        // DELETE: api/VehiculosDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculosDetalle(int id)
        {
            var vehiculosDetalle = await _context.VehiculosDetalle.FindAsync(id);
            if (vehiculosDetalle == null)
            {
                return NotFound();
            }

            _context.VehiculosDetalle.Remove(vehiculosDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculosDetalleExists(int id)
        {
            return _context.VehiculosDetalle.Any(e => e.DetalleId == id);
        }
    }
}
