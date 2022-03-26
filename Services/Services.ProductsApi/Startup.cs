using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Storage.Blobs;
using Business.ServiceProducts.AutoMapper;
using Business.ServiceProducts.Interfaces;
using Business.ServiceProducts.Logic;
using DataAccess.Azure.Interfaces;
using DataAccess.Azure.Repository;
using DataAccess.MongoDB.Interfaces.Configuration;
using DataAccess.MongoDB.Interfaces.Repository;
using DataAccess.MongoDB.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Services.ProductsApi
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });  
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Services.ProductsApi", Version = "v1" });
            });
            
            services.AddTransient<IProductsLogic, ProductsLogic>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddSingleton<IBlobService, BlobService>();
            //MongoDb
            services.Configure<StoreDataBaseSettings>(
                Configuration.GetSection(nameof(StoreDataBaseSettings)));

            services.AddSingleton<IStoreDataBaseSettings>(sp => 
            sp.GetRequiredService<IOptions<StoreDataBaseSettings>>().Value);
            services.AddControllers().AddNewtonsoftJson();
            //Azure
            services.AddSingleton(x =>
            new BlobServiceClient(connectionString:Configuration.GetValue<string>(key: "AzureBlobStorageConnectionsString")));

            //AutoMapper
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new MappingProfile());
            });
            IMapper iMapper = mapperConfig.CreateMapper();
            services.AddSingleton(iMapper);
            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Services.ProductsApi v1"));
            }

          app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
