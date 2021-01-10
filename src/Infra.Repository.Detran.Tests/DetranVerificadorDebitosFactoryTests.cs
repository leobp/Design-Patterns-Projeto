using DesignPatternSamples.App.Repository;
using DesignPatternSamples.Infra.Repository.Detran;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace DesignPatternsSamples.Infra.Repository.Detran.Tests
{
    public class DetranVerificadorPontosFactoryTests : IClassFixture<DependencyInjectionFixture>
    {
        private readonly IDetranVerificadorPontosFactory _Factory;

        public DetranVerificadorPontosFactoryTests(DependencyInjectionFixture dependencyInjectionFixture)
        {
            var serviceProvider = dependencyInjectionFixture.ServiceProvider;
            _Factory = serviceProvider.GetService<IDetranVerificadorPontosFactory>();
        }

        [Theory(DisplayName = "Dado um UF que está devidamente registrado no Factory devemos receber a sua implementação correspondente")]
        [InlineData("PE", typeof(DetranPEVerificadorPontosRepository))]
        [InlineData("SP", typeof(DetranSPVerificadorPontosRepository))]
        [InlineData("RJ", typeof(DetranRJVerificadorPontosRepository))]
        
        public void InstanciarServicoPorUFRegistrado(string uf, Type implementacao)
        {
            var resultado = _Factory.Create(uf);

            Assert.NotNull(resultado);
            Assert.IsType(implementacao, resultado);
        }

        [Fact(DisplayName = "Dado um UF que não está registrado no Factory devemos receber NULL")]
        public void InstanciarServicoPorUFNaoRegistrado()
        {
            IDetranVerificadorPontosRepository implementacao = _Factory.Create("CE");

            Assert.Null(implementacao);
        }
    }
}
