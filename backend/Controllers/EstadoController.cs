using AutoMapper;
using backend.DataAccess;
using backend.DTOs;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private IActividadService _actividadService;
        

        public EstadoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IActividadService actividadService, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _actividadService = actividadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoDTO>>> GetAranceles()
        {
            var estados = await _context.Estado.OrderBy(estado => estado.EstadoId).ToListAsync();
            return _mapper.Map<List<EstadoDTO>>(estados);
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> CrearEstado(EstadoDTO estadoDTO)
        {
            var estado = _mapper.Map<Estado>(estadoDTO);
            estado.EstadoId = 0;

            _context.Add(estado);
            var user = await _userManager.GetUserAsync(User);
            _actividadService.creaRegistro(user, "Creacion de estado");
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
