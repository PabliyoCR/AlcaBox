using backend.DataAccess;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IActividadService
    {
        void creaRegistro(ApplicationUser user, string accion);
    }

    public class ActividadService : IActividadService
    {
        private readonly ApplicationDbContext _context;

        public ActividadService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void creaRegistro(ApplicationUser user, string accion)
        {
            var registro = new BitacoraAccion { 
                    Accion = accion, 
                    Usuario =user,
                    Fecha = DateTime.Now
                };
            _context.Add(registro);
        }
    }
}
