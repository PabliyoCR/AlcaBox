using AutoMapper;
using backend.DataAccess;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            var usuarios = await _context.Users.OrderBy(user => user.nombre).ToListAsync();
            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        [HttpGet("byEmail")]    
        public async Task<ActionResult<UsuarioDTO>> GetUsuario([FromHeader] string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            return _mapper.Map<UsuarioDTO>(usuario);
        }


        [HttpGet("byRole/{roleName}")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> getUsersByRole(string roleName)
        {
            var rol =  _context.Roles.Single(role => role.Name.Equals(roleName));

            var usuarios_id = _context.UserRoles.Where(u => u.RoleId.Equals(rol.Id)).Select(u => u.UserId).ToList();

            List<ApplicationUser> usuarios = _context.Users.Where(r => usuarios_id.Contains(r.Id)).ToList();

            if (usuarios == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        [HttpGet("loginLogs")]
        public async Task<ActionResult<IEnumerable<LoginLogDTO>>> GetLoginLogs()
        {
            var logins = await _context.UserLogins.ToListAsync();
            logins.Reverse();
            return _mapper.Map<List<LoginLogDTO>>(logins);
        }

        [HttpGet("Actions")]
        public async Task<ActionResult<IEnumerable<BitacoraAccion>>> GetUserActions([FromHeader] DateTime fechaInicio, [FromHeader] DateTime fechaFinal)
        {
            var actions = await _context.BitacoraAccion.Where(action => action.Fecha >= fechaInicio && action.Fecha <= fechaFinal).ToListAsync();
            return _mapper.Map<List<BitacoraAccion>>(actions);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarUsuario(UsuarioEdicionDTO usuarioEdicionDTO)
        {
            var applicationUser = await _userManager.FindByIdAsync(usuarioEdicionDTO.id);

            if (applicationUser == null)
            {
                return NotFound();
            }

            applicationUser = _mapper.Map<UsuarioEdicionDTO, ApplicationUser>(usuarioEdicionDTO, applicationUser);

            var roles = await _userManager.GetRolesAsync(applicationUser);
            await _userManager.RemoveFromRolesAsync(applicationUser, roles.ToArray());
            await _userManager.AddToRoleAsync(applicationUser, usuarioEdicionDTO.roleId);
            await _userManager.UpdateAsync(applicationUser);

            return NoContent();
        }
    }
}
