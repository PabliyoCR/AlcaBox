using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Packages
{
    public class PackagesService
    {
        private UserManager<IdentityUser> _userManger;
        private IConfiguration _configuration;

        public PackagesService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManger = userManager;
            _configuration = configuration;
        }

        //public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        //{
           

        //}
    }
}
