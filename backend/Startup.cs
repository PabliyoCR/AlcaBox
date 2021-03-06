using AutoMapper;
using backend.DataAccess;
using backend.Models;
using backend.Services;
using backend.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Mapeo Entidades
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles(provider.GetService<ApplicationDbContext>(), provider.GetService<UserManager<ApplicationUser>>()));
            }).CreateMapper());

            // Conexion con la Base de datos
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Identificación de Usuarios
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                //options.SignIn.RequireConfirmedAccount = true
            }).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IdentityErrorDescriber, CustomIdentityErrorDescriber>();

            //Autenticacion de usuarios
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        //ValidAudience = Configuration["AuthSettings:Audience"],
                        //ValidIssuer = Configuration["AuthSettings:Issuer"],
                        RequireExpirationTime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["AuthSettings:Key"])),
                        ClockSkew = TimeSpan.Zero
                    });

            //Autorizacion de usuarios
            services.AddAuthorization(options => {
                options.AddPolicy("EsAdmin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("EsFuncionario", policy => policy.RequireRole("Funcionario"));
                options.AddPolicy("EsUsuario", policy => policy.RequireRole("Usuario"));
            });

            //Permisos CORS
            services.AddCors(options => {
                options.AddDefaultPolicy(builder => {
                    builder.WithOrigins(Configuration["ConfiguracionJWT:Client_URL"].ToString()).AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IMailService, SendGridMailService>();

            services.AddTransient<IActividadService, ActividadService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "backend", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                         new string[]{ }
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "backend v1"));
            }

            app.UseHttpsRedirection();

            // Servir archivos estaticos de Angular
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
