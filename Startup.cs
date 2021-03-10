using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProductManagerBackend.Models;
using ProductManagerBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagerBackend
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
            services.AddCors();

            services.AddControllers().AddNewtonsoftJson(options=>options.SerializerSettings.ReferenceLoopHandling 
            = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductManagerBackend", Version = "v1" });
            });

            services.AddScoped<ProductDbContext>();

            var mapperconfig = new MapperConfiguration(x => x.AddProfile(new ProductAutoMapper()));
            IMapper serviceMapper = mapperconfig.CreateMapper();
            services.AddSingleton(serviceMapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductManagerBackend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => 
                            options.AllowAnyOrigin()
                            //WithOrigins(
                            //    //"https://localhost:5001", "http://localhost:5000",
                            //    "https://localhost:44370",
                            //    "https://localhost:5005",
                            //    "http://localhost:5006",
                            //    "http://localhost:4200",
                            //    "https://localhost:44386/"
                            //    )
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                //.AllowCredentials()
                                );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
