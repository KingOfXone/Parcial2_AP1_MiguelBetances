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
    public class VehiculosController : ControllerBase
    {
        private readonly Contexto _context;

        public VehiculosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Vehiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculos>>> GetVehiculos()
        {
            return await _context.Vehiculos.ToListAsync();
        }

        // GET: api/Vehiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculos>> GetVehiculos(int id)
        {
            if (_context.Vehiculos == null)
            {
                return NotFound();
            }
            var vehiculos = await _context.Vehiculos
                .Include(c => c.VehiculosDetalle)
                .Where(c => c.VehiculoId == id)
                .FirstOrDefaultAsync();

            if (vehiculos == null)
            {
                return NotFound();
            }

            return vehiculos;
        }




        // PUT: api/Vehiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculos(int id, Vehiculos vehiculos)
        {
            if (id != vehiculos.VehiculoId)
            {
                return BadRequest();
            }

            var existingVehiculo = await _context.Vehiculos
                .Include(v => v.VehiculosDetalle)
                .FirstOrDefaultAsync(v => v.VehiculoId == id);

            if (existingVehiculo == null)
            {
                return NotFound();
            }

            // Actualizar las propiedades principales del vehículo
            _context.Entry(existingVehiculo).CurrentValues.SetValues(vehiculos);

            // Eliminar detalles que ya no están presentes en la versión actualizada
            foreach (var existingDetalle in existingVehiculo.VehiculosDetalle.ToList())
            {
                if (!vehiculos.VehiculosDetalle.Any(d => d.Id == existingDetalle.Id))
                    _context.VehiculosDetalle.Remove(existingDetalle);
            }

            // Actualizar y agregar detalles
            foreach (var updatedDetalle in vehiculos.VehiculosDetalle)
            {
                var existingDetalle = existingVehiculo.VehiculosDetalle
                    .FirstOrDefault(d => d.Id == updatedDetalle.Id);

                if (existingDetalle != null)
                    // Actualizar el detalle existente
                    _context.Entry(existingDetalle).CurrentValues.SetValues(updatedDetalle);
                else
                {
                    // Configurar la clave foránea y agregar un nuevo detalle
                    updatedDetalle.VehiculosId = id;
                    existingVehiculo.VehiculosDetalle.Add(updatedDetalle);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculosExists(id))
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

        // POST: api/Vehiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehiculos>> PostVehiculos(Vehiculos vehiculos)
        {
            _context.Vehiculos.Add(vehiculos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculos", new { id = vehiculos.VehiculoId }, vehiculos);
        }

        // DELETE: api/Vehiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculos(int id)
        {
            try
            {
                var vehiculos = await _context.Vehiculos
                    .Include(v => v.VehiculosDetalle)
                    .FirstOrDefaultAsync(v => v.VehiculoId == id);

                if (vehiculos == null)
                {
                    return NotFound();
                }

                // Eliminar los detalles del vehículo
                _context.VehiculosDetalle.RemoveRange(vehiculos.VehiculosDetalle);

                // Eliminar el vehículo
                _context.Vehiculos.Remove(vehiculos);

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Aquí puedes registrar la excepción
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        private bool VehiculosExists(int id)
        {
            return _context.Vehiculos.Any(e => e.VehiculoId == id);
        }
    }
}
