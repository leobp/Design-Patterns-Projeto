using AutoMapper;
using DesignPatternSamples.App.Decorators;
using DesignPatternSamples.App.Implementations;
using DesignPatternSamples.App.Repository;
using DesignPatternSamples.App.Services;
using DesignPatternSamples.Infra.Repository.Detran;
using DesignPatternSamples.WebAPI.Middlewares;
using DesignPatternSamples.WebAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using Workbench.DependencyInjection.Extensions;

namespace DesignPatternSamples.WebAPI
{
    public class Startup
    {
        protected const string HEALTH_PATH = "/health";

        protected readonly IConfiguration _Configuration;

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region HealthCheck
            services.AddHealthChecks();
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesignPatternSamples", Version = "v1" });
            });
            #endregion

            services.AddDependencyInjection()
                .AddAutoMapper();

            /*Cache distribu�do FAKE*/
            services.AddDistributedMemoryCache();
            
            services.AddControllers();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add(new ProducesResponseTypeAttribute(typeof(FailureResultModel), 500));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region HealthCheck
            app.UseHealthChecks(HEALTH_PATH);
            #endregion

            #region Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseDetranVerificadorPontosFactory();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseMvc();
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            return services
                .AddTransient<IDetranVerificadorPontosService, DetranVerificadorPontosServices>()
                .Decorate<IDetranVerificadorPontosService, DetranVerificadorPontosDecoratorCache>()
                .Decorate<IDetranVerificadorPontosService, DetranVerificadorPontosDecoratorLogger>()
                .AddSingleton<IDetranVerificadorPontosFactory, DetranVerificadorPontosFactory>()
                .AddTransient<DetranPEVerificadorPontosRepository>()
                .AddTransient<DetranSPVerificadorPontosRepository>()
                .AddTransient<DetranRJVerificadorPontosRepository>()
                .AddScoped<ExceptionHandlingMiddleware>();
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsSubclassOf(typeof(Profile)));

            return services.AddAutoMapper(types.ToArray());
        }
    }

    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseDetranVerificadorPontosFactory(this IApplicationBuilder app)
        {
            app.ApplicationServices.GetService<IDetranVerificadorPontosFactory>()
                .Register("PE", typeof(DetranPEVerificadorPontosRepository))
                .Register("RJ", typeof(DetranRJVerificadorPontosRepository))
                .Register("SP", typeof(DetranSPVerificadorPontosRepository))
                ;

            return app;
        }
    }
}
