using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.DataAccess;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaquetesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public PaquetesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        // GET: api/Paquetes
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<PaqueteDTO>>> GetPaquetes([FromHeader] string metodoOrden)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var roles_user = await _userManager.GetRolesAsync(user);

            List<Paquete> paquetes;
            if (roles_user.Contains("Usuario"))
            {
                paquetes = await _context.Paquete.Where(paq => paq.UsuarioId == _userManager.GetUserId(User)).OrderBy(paquete => paquete.FechaRegistro).ToListAsync();
                return _mapper.Map<List<PaqueteDTO>>(paquetes);
            }
            else
            {

                switch (metodoOrden)
                {
                    case "FechaRegistro":
                        paquetes = await _context.Paquete.OrderBy(paquete => paquete.FechaRegistro).ToListAsync();
                        paquetes.Reverse(); 
                        break;
                    case "Estado":
                        paquetes = await _context.Paquete.OrderBy(paquete => paquete.Estado).ToListAsync();
                        break;
                    case "Usuario":
                        paquetes = await _context.Paquete.OrderBy(paquete => paquete.Usuario).ToListAsync();
                        break;
                    default:
                        paquetes = await _context.Paquete.ToListAsync();
                        break;
                }
            }
            return _mapper.Map<List<PaqueteDTO>>(paquetes);
        }

        // GET: api/Paquetes/5
        [HttpGet("{id}", Name = "GetPaquete")]
        public async Task<ActionResult<PaqueteDTO>> GetPaquete(int id)
        {
            var paquete = await _context.Paquete.FirstOrDefaultAsync(x => x.PaqueteId == id);

            if (paquete == null)
            {
                return NotFound();
            }

            return _mapper.Map<PaqueteDTO>(paquete);
        }

        [HttpGet("User/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<PaqueteDTO>>> GetPaquetesUsuario(string id)
        {
            var userId = _userManager.GetUserId(User);

            var paquetes = await _context.Paquete.Where(paq => paq.UsuarioId == id).OrderBy(paquete => paquete.FechaRegistro).ToListAsync();
            return _mapper.Map<List<PaqueteDTO>>(paquetes);
        }

        [HttpGet("Estados")]
        public async Task<ActionResult<IEnumerable<PaqueteDTO>>> GetPaquetesEstados([FromHeader] int[] estados)
        {
            var paquetes = await _context.Paquete.Where(paq => estados.Contains(paq.EstadoId)).OrderBy(paquete => paquete.Estado.Nombre).ToListAsync();
            return _mapper.Map<List<PaqueteDTO>>(paquetes);
        }

        // POST: api/Paquetes
        [HttpPost]
        public async Task<ActionResult<PaqueteDTO>> PostPaquete(PaqueteCreacionDTO paqueteCreacionDTO)
        {
            var paquete = _mapper.Map<Paquete>(paqueteCreacionDTO);

            _context.Add(paquete);
            await _context.SaveChangesAsync();

            var paqueteDTO = _mapper.Map<PaqueteDTO>(paquete);

            return CreatedAtRoute("GetPaquete", new { id = paquete.PaqueteId }, paqueteDTO);
        }


        // PUT: api/Paquetes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutPaquete(PaqueteCreacionDTO paqueteCreacionDTO)
        {
            var existe = await _context.Paquete.AnyAsync(x => x.PaqueteId == paqueteCreacionDTO.PaqueteId);

            if (!existe)
            {
                return NotFound();
            }

            var paquete = _mapper.Map<Paquete>(paqueteCreacionDTO);
  
            _context.Update(paquete);
            await _context.SaveChangesAsync();

            return NoContent();
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
            return _context.Paquete.Any(e => e.PaqueteId == id);
        }
    }
}
