using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersystemBack2._0.Models;
using PersystemBack2._0.ModelsView;

namespace PersystemBack2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly PersystemContext _context;

        public ServicioController(PersystemContext context)
        {
            _context = context;
        }

        // GET: api/Servicio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicioMV>>> GetServicios()
        {
          if (_context.Servicios == null)
          {
              return NotFound();
            }
            var query = from servicio in await _context.Servicios.ToListAsync()
                        join Material in await _context.Materials.ToListAsync() on servicio.CodMat equals Material.CodMat
                        select new ServicioMV
                        {
                            Codigo=servicio.CodSer,
                            Precio=servicio.PrecioSer,
                            Duracion=servicio.DuracionSer,
                            Nombre=servicio.NomSer,
                            Tipo=servicio.TipoSer,
                            Descripcion=servicio.DesSer,
                            Material=Material.NomMat
                        };
            return query.ToList();

        }
          
        

        // GET: api/Servicio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetServicio(string id)
        {
          if (_context.Servicios == null)
          {
              return NotFound();
          }
            var servicio = await _context.Servicios.FindAsync(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;
        }

        // PUT: api/Servicio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicio(string id, Servicio servicio)
        {
            if (id != servicio.CodSer)
            {
                return BadRequest();
            }

            _context.Entry(servicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(id))
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

        // POST: api/Servicio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Servicio>> PostServicio(Servicio servicio)
        {
          if (_context.Servicios == null)
          {
              return Problem("Entity set 'PersystemContext.Servicios'  is null.");
          }
            _context.Servicios.Add(servicio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServicioExists(servicio.CodSer))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetServicio", new { id = servicio.CodSer }, servicio);
        }

        // DELETE: api/Servicio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicio(string id)
        {
            if (_context.Servicios == null)
            {
                return NotFound();
            }
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicioExists(string id)
        {
            return (_context.Servicios?.Any(e => e.CodSer == id)).GetValueOrDefault();
        }
    }
}
