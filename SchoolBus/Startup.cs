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
//
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
      
            services.AddScoped<IStationDL, StationDL>();
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
            services.AddDbContext<SchoolBusContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SchoolBusHome1")), ServiceLifetime.Scoped);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolBus", Version = "v1" });
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("server is up!!:)");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolBus v1"));
            }

            app.UseErrorsMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
