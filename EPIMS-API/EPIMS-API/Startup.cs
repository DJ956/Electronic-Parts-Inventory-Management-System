using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Factory;
using EPIMS_API.Domain.Repository;
using EPIMS_API.Infra.Factory;
using EPIMS_API.Infra.Repository;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EPIMS_API
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
            //DI
            //Repository
            services.AddScoped<ICategoryRepository, CategoryImplRepository>();
            services.AddScoped<IProductRepository, ProductImplRepository>();
            services.AddScoped<IProductDetailRepository, ProductDetailImplRepository>();
            services.AddScoped<ICodeMasterRepository, CodeMasterImplRepository>();
            services.AddScoped<IInventoryRepository, InventoryImplRepository>();

            //Factory
            services.AddScoped<IProductModelFactory, ProductModelFactory>();
            services.AddScoped<IProductDetailModelFactory, ProductDetailModelFactory>();
            services.AddScoped<IInventoryModelFactory, InventoryModelFactory>();

            //DBê⁄ë±ï∂éöóÒê›íË
            services.AddDbContext<EPIMSContext>(options =>
           {
               options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
           });

            //CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
               {
                   builder.WithOrigins("http://localhost:8100");
               });
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.WriteIndented = true;
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EPIMS_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EPIMS_API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            //CORS
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
