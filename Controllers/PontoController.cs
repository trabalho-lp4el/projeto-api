using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using projeto_api.Models;

namespace projeto_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PontoController : ControllerBase
    {
        private readonly AplicacaoContext _context;

        public PontoController(AplicacaoContext context)
        {
            _context = context;
        }

        // GET: api/Ponto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ponto>>> GetPonto()
        {
            return await _context.Ponto.ToListAsync();
        }

        // GET: api/Ponto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ponto>> GetPonto(long id)
        {
            var ponto = await _context.Ponto.FindAsync(id);

            if (ponto == null)
            {
                return NoContent();
            }

            return ponto;
        }

        // GET: api/Ponto/usuario/5
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Ponto>>> GetPontoByUsuario(long usuarioId)
        {
            var pontos = await _context.Ponto
                .Where(ponto => ponto.UsuarioId == usuarioId)
                .ToListAsync();

            if (!pontos.Any())
            {
                return NoContent();
            }

            return pontos;
        }

        // PUT: api/Ponto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPonto(long id, Ponto ponto)
        {
            if (id != ponto.Id)
            {
                return BadRequest();
            }

            _context.Entry(ponto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PontoExists(id))
                {
                    return NoContent();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ponto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ponto>> PostPonto(Ponto ponto)
        {
            var usuario = _context.Usuario.FindAsync(ponto.UsuarioId);

            if (!(usuario.Result == null))
            {
                _context.Ponto.Add(ponto);
                await _context.SaveChangesAsync();
                
                return CreatedAtAction("GetPonto", new { id = ponto.Id }, ponto);
            }

            return BadRequest();
        }

        // DELETE: api/Ponto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ponto>> DeletePonto(long id)
        {
            var ponto = await _context.Ponto.FindAsync(id);
            
            if (ponto == null)
            {
                return NoContent();
            }

            _context.Ponto.Remove(ponto);
            await _context.SaveChangesAsync();

            return ponto;
        }

        private bool PontoExists(long id)
        {
            return _context.Ponto.Any(e => e.Id == id);
        }
    }
}
