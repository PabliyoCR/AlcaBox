using AutoMapper;
using backend.DataAccess;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EstadoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoDTO>>> GetAranceles()
        {
            var estados = await _context.Estado.OrderBy(estado => estado.EstadoId).ToListAsync();
            return _mapper.Map<List<EstadoDTO>>(estados);
        }


        [HttpPost]
        public async Task<ActionResult> CrearEstado(EstadoDTO estadoDTO)
        {
            var estado = _mapper.Map<Estado>(estadoDTO);
            estado.EstadoId = 0;

            _context.Add(estado);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarEstado(EstadoDTO estadoDTO)
        {
            var existe = await _context.Estado.AnyAsync(x => x.EstadoId == estadoDTO.EstadoId);

            if (!existe)
            {
                return NotFound();
            }

            var estado = _mapper.Map<Estado>(estadoDTO);

            _context.Update(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEstado(int id)
        {
            var estado = await _context.Estado.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.Estado.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
