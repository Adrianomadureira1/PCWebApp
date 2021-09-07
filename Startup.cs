using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PCWebApp.Repository;
using Microsoft.EntityFrameworkCore;
using PCWebApp.Repository.Interfaces;
using PCWebApp.Repository.Entity;
using PCWebApp.Services;
using PCWebApp.Services.Interface;
using System.Reflection;
using System.IO;
using Swashbuckle.AspNetCore.Filters;

namespace PCWebApp
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
            services.AddScoped<IColaboradorRepository<Colaborador>, ColaboradorRepository<Colaborador>>();

            services.AddScoped<IColaboradorService, ColaboradorService>();

            services.AddEntityFrameworkNpgsql().AddDbContext<PCDbContext>(opt => 
            opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options => {
                    options.SuppressModelStateInvalidFilter = true;
                    options.SuppressMapClientErrors = true;
                });

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Documentação da PCWebApp API", 
                Version = "v1", 
                Description = "WebApp para divulgação do perfil de colaboradores de uma empresa.",
                Contact = new OpenApiContact { 
                    Name = "Adriano Madureira",
                    Email = "adrianomadureira1@gmail.com",
                    Url = new Uri("http://github.com/Adrianomadureira1")
                    }});

                c.ExampleFilters();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

            services.AddSwaggerExamplesFromAssemblyOf<Startup>();
            
            services.AddCors(options => 
            {
                options.AddPolicy(name: "Origins",
                builder => {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PCWebApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Origins");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty; // Ou "swagger" que seria a rota pra acessar o swagger.
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}