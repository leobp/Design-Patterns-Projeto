using DesignPatternSamples.App.Repository;
using DesignPatternSamples.Infra.Repository.Detran;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DesignPatternsSamples.Infra.Repository.Detran.Tests
{
    public class DependencyInjectionFixture
    {
        public readonly IServiceProvider ServiceProvider;

        public DependencyInjectionFixture()
        {
            var services = new ServiceCollection()
                .AddLogging()
                .AddTransient<DetranPEVerificadorPontosRepository>()
                .AddTransient<DetranSPVerificadorPontosRepository>()
                .AddTransient<DetranRJVerificadorPontosRepository>()
                .AddSingleton<IDetranVerificadorPontosFactory, DetranVerificadorPontosFactory>();

            #region IConfiguration
            services.AddTransient<IConfiguration>((services) =>
                new ConfigurationBuilder()

                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .Build()
            );
            #endregion

            ServiceProvider = services.BuildServiceProvider();

            ServiceProvider.GetService<IDetranVerificadorPontosFactory>()
                .Register("PE", typeof(DetranPEVerificadorPontosRepository))
                .Register("RJ", typeof(DetranRJVerificadorPontosRepository))
                .Register("SP", typeof(DetranSPVerificadorPontosRepository))
                ;
        }
    }
}