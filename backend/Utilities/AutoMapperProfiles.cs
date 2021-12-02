using AutoMapper;
using backend.DataAccess;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AutoMapperProfiles(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

            CreateMap<ApplicationUser, UsuarioDTO>()
                .ForMember(user => user.roleId, opciones => opciones.MapFrom(MapUsuarioDTO));

            CreateMap<UsuarioCreacionDTO, ApplicationUser>();
            CreateMap<UsuarioEdicionDTO, ApplicationUser>();

            CreateMap<Paquete, PaqueteDTO>()
              .ForMember(paquete => paquete.Usuario, opciones => opciones.MapFrom(MapUsuarioPaquete))
              .ForMember(paquete => paquete.Arancel, opciones => opciones.MapFrom(MapArancelPaquete))
              .ForMember(paquete => paquete.Estado, opciones => opciones.MapFrom(MapEstadoPaquete));

            CreateMap<PaqueteCreacionDTO, Paquete>();

            CreateMap<Estado, EstadoDTO>().ReverseMap();

            CreateMap<Arancel, ArancelDTO>().ReverseMap();
        }
        private string MapUsuarioDTO(ApplicationUser user, UsuarioDTO usuarioDTO)
        {
            var roles_user = _userManager.GetRolesAsync(user).Result.ToList();
            return roles_user[0];
        }

        private ApplicationUser MapUsuarioPaquete(Paquete paquete, PaqueteDTO paqueteDTO)
        {
            var usuario = _userManager.FindByIdAsync(paquete.UsuarioId).Result;
            return usuario;
        }

        private Arancel MapArancelPaquete(Paquete paquete, PaqueteDTO paqueteDTO)
        {
            var arancel = _context.Arancel.FirstOrDefaultAsync(x => x.ArancelId == paquete.ArancelId).Result;
            return arancel;
        }

        private Estado MapEstadoPaquete(Paquete paquete, PaqueteDTO paqueteDTO)
        {
            var estado = _context.Estado.FirstOrDefaultAsync(x => x.EstadoId == paquete.EstadoId).Result;
            return estado;
        }
    }
}
