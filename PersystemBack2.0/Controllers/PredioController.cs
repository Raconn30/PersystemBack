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
    public class PredioController : ControllerBase
    {
        private readonly PersystemContext _context;

        public PredioController(PersystemContext context)
        {
            _context = context;
        }

        // GET: api/Predio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PredioMV>>> GetPredios()
        {
          if (_context.Predios == null)
          {
              return NotFound();
          }
            var query = from predio in await _context.Predios.ToListAsync()
                        join representante in await _context.Representantes.ToListAsync() on predio.DocumentoRepre equals representante.DocumentoRepre
                        select new PredioMV
                        {
                            Nit = predio.NitPredio,
                            Nombre = predio.NomPredio,
                            Cuartos = predio.CuartosPredio,
                            Tipo_Cuarto = predio.TipoCuarto,
                            Direccion = predio.DirPredio,
                            Correo = predio.CorreoPredio,
                            Representante = representante.NomRepre

                        };
            return query.ToList();

        }

        // GET: api/Predio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Predio>> GetPredio(string id)
        {
          if (_context.Predios == null)
          {
              return NotFound();
          }
            var predio = await _context.Predios.FindAsync(id);

            if (predio == null)
            {
                return NotFound();
            }

            return predio;
        }

        // PUT: api/Predio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPredio(string id, Predio predio)
        {
            if (id != predio.NitPredio)
            {
                return BadRequest();
            }

            _context.Entry(predio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredioExists(id))
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

        // POST: api/Predio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Predio>> PostPredio(Predio predio)
        {
          if (_context.Predios == null)
          {
              return Problem("Entity set 'PersystemContext.Predios'  is null.");
          }
            _context.Predios.Add(predio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PredioExists(predio.NitPredio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPredio", new { id = predio.NitPredio }, predio);
        }

        // DELETE: api/Predio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePredio(string id)
        {
            if (_context.Predios == null)
            {
                return NotFound();
            }
            var predio = await _context.Predios.FindAsync(id);
            if (predio == null)
            {
                return NotFound();
            }

            _context.Predios.Remove(predio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PredioExists(string id)
        {
            return (_context.Predios?.Any(e => e.NitPredio == id)).GetValueOrDefault();
        }
    }
}
