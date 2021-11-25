using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.DataAccess;
using backend.Models;
using backend.Utilities;
using backend.DTOs;
using AutoMapper;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaquetesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PaquetesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Paquetes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaqueteDTO>>> GetPaquete([FromQuery] PaginacionDTO paginacionDTO)
        {
            //return await _context.Paquete.ToListAsync();

            var queryable = _context.Paquete.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var paquetes = await queryable.OrderBy(x => x.Paquete_Id).Paginar(paginacionDTO).ToListAsync();
            return _mapper.Map<List<PaqueteDTO>>(paquetes);
        }

        // GET: api/Paquetes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paquete>> GetPaquete(int id)
        {
            var paquete = await _context.Paquete.FindAsync(id);

            if (paquete == null)
            {
                return NotFound();
            }

            return paquete;
        }

        // PUT: api/Paquetes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaquete(int id, Paquete paquete)
        {
            if (id != paquete.Paquete_Id)
            {
                return BadRequest();
            }

            _context.Entry(paquete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaqueteExists(id))
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

        // POST: api/Paquetes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paquete>> PostPaquete(Paquete paquete)
        {
            _context.Paquete.Add(paquete);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaquete", new { id = paquete.Paquete_Id }, paquete);
        }

        // DELETE: api/Paquetes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaquete(int id)
        {
            var paquete = await _context.Paquete.FindAsync(id);
            if (paquete == null)
            {
                return NotFound();
            }

            _context.Paquete.Remove(paquete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaqueteExists(int id)
        {
            return _context.Paquete.Any(e => e.Paquete_Id == id);
        }
    }
}
