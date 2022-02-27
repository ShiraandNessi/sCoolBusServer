using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL;
using BL;
using AutoMapper;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SchoolBus
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IStationOfRoutDL, StationOfRoutDL>();
            services.AddResponseCaching();
            services.AddScoped<IStationDL, StationDL>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IStudentStatuseBL, StudentStatuseBL>();
            services.AddScoped<IStudentStatuseDL, StudentStatuseDL>();
            services.AddScoped<IStationBL, StationBL>();
            services.AddScoped<IStudentDL, StudentDL>();
            services.AddScoped<IStudentBL, StudentBL>();
            services.AddScoped<IMessegeDL, MessegeDL>();
            services.AddScoped<IMessegeBL, MessegeBL>();
            services.AddScoped<IDriverDL, DriverDL>();
            services.AddScoped<IDriverBL, DriverBL>();
            services.AddScoped<IUserDL, UserDL>();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IFamilyBL, FamilyBL>();
            services.AddScoped<IFamilyDL, FamilyDL>();
            services.AddScoped<IRouteBL, RouteBL>();
            services.AddScoped<IRouteDL, RouteDL>();
            services.AddScoped<IAuthorizationFuncs, AuthorizationFuncs>();
            services.AddDbContext<SchoolBusContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SchoolBus")), ServiceLifetime.Scoped);
            services.AddControllers();
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("key").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolBus", Version = "v1" });

                // To Enable authorization using Swagger (JWT)    
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseErrorsMiddleware();
            logger.LogInformation("server is up!!:)");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolBus v1"));
            }
            
           
            app.UseHttpsRedirection();
            app.UseResponseCaching();
            app.UseCacheMiddleware();
            app.UseAuthentication();
            app.UseRouting();
           
          

            app.Map("/api", app2 =>
            {   
                app2.UseAuthentication(); 
                app2.UseRouting();
                app2.UseRatingMiddleware();
                app2.UseAuthorization();

                app2.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
            app.UseRatingMiddleware();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
