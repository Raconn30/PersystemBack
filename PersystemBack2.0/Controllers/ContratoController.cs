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
    public class ContratoController : ControllerBase
    {
        private readonly PersystemContext _context;

        public ContratoController(PersystemContext context)
        {
            _context = context;
        }

        // GET: api/Contrato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContratosMV>>> GetContratos()
        {
          if (_context.Contratos == null)
          {
              return NotFound();
          }
            var query = from contratos in await _context.Contratos.ToListAsync()
                        join predios in await _context.Predios.ToListAsync() on contratos.NitPredio equals predios.NitPredio
                        join servicios in await _context.Servicios.ToListAsync() on contratos.CodSer equals servicios.CodSer
                        select new ContratosMV
                        {
                            Codigo= contratos.CodContrato,
                            FechaInicio = contratos.FechaInicioContr,
                            FechaFinal = contratos.FechaFinalContr,
                            Servicio = servicios.NomSer,
                            Predio = predios.NomPredio
                        };
           return  query.ToList();
        }

        // GET: api/Contrato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> GetContrato(string id)
        {
          if (_context.Contratos == null)
          {
              return NotFound();
          }
            var contrato = await _context.Contratos.FindAsync(id);

            if (contrato == null)
            {
                return NotFound();
            }

            return contrato;
        }

        // PUT: api/Contrato/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrato(string id, Contrato contrato)
        {
            if (id != contrato.CodContrato)
            {
                return BadRequest();
            }

            _context.Entry(contrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(id))
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

        // POST: api/Contrato
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contrato>> PostContrato(Contrato contrato)
        {
          if (_context.Contratos == null)
          {
              return Problem("Entity set 'PersystemContext.Contratos'  is null.");
          }
            _context.Contratos.Add(contrato);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContratoExists(contrato.CodContrato))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContrato", new { id = contrato.CodContrato }, contrato);
        }

        // DELETE: api/Contrato/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContrato(string id)
        {
            if (_context.Contratos == null)
            {
                return NotFound();
            }
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }

            _context.Contratos.Remove(contrato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContratoExists(string id)
        {
            return (_context.Contratos?.Any(e => e.CodContrato == id)).GetValueOrDefault();
        }
    }
}
