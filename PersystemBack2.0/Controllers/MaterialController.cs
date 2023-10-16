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
    public class MaterialController : ControllerBase
    {
        private readonly PersystemContext _context;

        public MaterialController(PersystemContext context)
        {
            _context = context;
        }

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialVM>>> GetMaterials()
        {
          if (_context.Materials == null)
          {
              return NotFound();
          }
            var query = from material in await _context.Materials.ToListAsync()
                        
                        select new MaterialVM
                        {
                            Codigo = material.CodMat,
                            Nombre = material.NomMat,
                            Tipo = material.TipoMat,
                            Precio = material.PrecioMat,
                            Descripcion = material.DesMat,
                            Unidades = material.NumUnidades,
                            FechaEntrada = material.FechaEntrada,
                            FechaSalida = material.FechaSalida
                        };
            return query.ToList();
        }

        // GET: api/Materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(string id)
        {
          if (_context.Materials == null)
          {
              return NotFound();
          }
            var material = await _context.Materials.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        // PUT: api/Materials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(string id, Material material)
        {
            if (id != material.CodMat)
            {
                return BadRequest();
            }

            _context.Entry(material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Materials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(Material material)
        {
          if (_context.Materials == null)
          {
              return Problem("Entity set 'PersystemContext.Materials'  is null.");
          }
            _context.Materials.Add(material);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MaterialExists(material.CodMat))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaterial", new { id = material.CodMat }, material);
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(string id)
        {
            if (_context.Materials == null)
            {
                return NotFound();
            }
            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialExists(string id)
        {
            return (_context.Materials?.Any(e => e.CodMat == id)).GetValueOrDefault();
        }
    }
}
