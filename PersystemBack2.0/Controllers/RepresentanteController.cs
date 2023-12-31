﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersystemBack2._0.Models;

namespace PersystemBack2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentanteController : ControllerBase
    {
        private readonly PersystemContext _context;

        public RepresentanteController(PersystemContext context)
        {
            _context = context;
        }

        // GET: api/Representantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Representante>>> GetRepresentantes()
        {
          if (_context.Representantes == null)
          {
              return NotFound();
          }
            return await _context.Representantes.ToListAsync();
        }

        // GET: api/Representantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Representante>> GetRepresentante(string id)
        {
          if (_context.Representantes == null)
          {
              return NotFound();
          }
            var representante = await _context.Representantes.FindAsync(id);

            if (representante == null)
            {
                return NotFound();
            }

            return representante;
        }

        // PUT: api/Representantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepresentante(string id, Representante representante)
        {
            if (id != representante.DocumentoRepre)
            {
                return BadRequest();
            }

            _context.Entry(representante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepresentanteExists(id))
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

        // POST: api/Representantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Representante>> PostRepresentante(Representante representante)
        {
          if (_context.Representantes == null)
          {
              return Problem("Entity set 'PersystemContext.Representantes'  is null.");
          }
            _context.Representantes.Add(representante);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RepresentanteExists(representante.DocumentoRepre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRepresentante", new { id = representante.DocumentoRepre }, representante);
        }

        // DELETE: api/Representantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepresentante(string id)
        {
            if (_context.Representantes == null)
            {
                return NotFound();
            }
            var representante = await _context.Representantes.FindAsync(id);
            if (representante == null)
            {
                return NotFound();
            }

            _context.Representantes.Remove(representante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepresentanteExists(string id)
        {
            return (_context.Representantes?.Any(e => e.DocumentoRepre == id)).GetValueOrDefault();
        }
    }
}
