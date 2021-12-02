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
    public class ArancelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ArancelController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArancelDTO>>> GetAranceles()
        {
            var aranceles = await _context.Arancel.OrderBy(arancel => arancel.ArancelId).ToListAsync();
            return _mapper.Map<List<ArancelDTO>>(aranceles);
        }


        [HttpPost]
        public async Task<ActionResult> CrearArancel(ArancelDTO arancelDTO)
        {
            var arancel = _mapper.Map<Arancel>(arancelDTO);

            _context.Add(arancel);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarArancel(ArancelDTO arancelDTO)
        {
            var existe = await _context.Arancel.AnyAsync(x => x.ArancelId == arancelDTO.ArancelId);

            if (!existe)
            {
                return NotFound();
            }

            var arancel = _mapper.Map<Arancel>(arancelDTO);

            _context.Update(arancel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarArancel(int id)
        {
            var arancel = await _context.Arancel.FindAsync(id);
            if (arancel == null)
            {
                return NotFound();
            }

            _context.Arancel.Remove(arancel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
