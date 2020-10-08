using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramworkCosmos.Contracts;
using EntityFramworkCosmos.Models;
using EntityFramworkCosmos.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace EntityFramworkCosmos
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
            services.AddControllers();

            // DB-Context
            services.AddDbContext<MessageDbContext>(options =>
                options.UseCosmos("https://mycosmodbv1.documents.azure.com",
                    "rn1m4FUDBwEFLQMYnY76MWKQcCf9AmX4p2J6KLOA9coSimKEdAUyh6hQV5dUEEK6b5mNg5kYvgQGuC7pJd3VKg==",
                    databaseName: "OrdersDB"));
            services.AddDbContext<CaseDbContext>(options =>
                options.UseCosmos("https://mycosmodbv1.documents.azure.com",
                    "rn1m4FUDBwEFLQMYnY76MWKQcCf9AmX4p2J6KLOA9coSimKEdAUyh6hQV5dUEEK6b5mNg5kYvgQGuC7pJd3VKg==",
                    databaseName: "OrdersDB"));
            // Repository
            services.AddCosmosRepository(Configuration,
                options =>
                {
                    options.CosmosConnectionString = Configuration.GetValue<string>("CosmosDB:ConnectionString");
                    options.DatabaseId = Configuration.GetValue<string>("CosmosDB:DatabaseId");
                    options.ContainerId = "Message";
                });
            /*
            services.AddCosmosRepository(Configuration,
                options =>
                {
                    options.CosmosConnectionString = Configuration.GetValue<string>("CosmosDB:ConnectionString");
                    options.DatabaseId = Configuration.GetValue<string>("CosmosDB:DatabaseId");
                    options.ContainerId = "Case";
                }); */


            // DI-Services
            services.AddSingleton<IAzureStorageClient, StorageClientService>();
            services.AddSingleton<IStorageClientCredential, StorageClientCredentialService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
