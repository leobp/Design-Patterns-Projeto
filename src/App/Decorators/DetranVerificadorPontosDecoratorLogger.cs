using DesignPatternSamples.App.DTO;
using DesignPatternSamples.App.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DesignPatternSamples.App.Decorators
{
    public class DetranVerificadorPontosDecoratorLogger : IDetranVerificadorPontosService
    {
        private readonly IDetranVerificadorPontosService _Inner;
        private readonly ILogger<DetranVerificadorPontosDecoratorLogger> _Logger;

        public DetranVerificadorPontosDecoratorLogger(
            IDetranVerificadorPontosService inner,
            ILogger<DetranVerificadorPontosDecoratorLogger> logger)
        {
            _Inner = inner;
            _Logger = logger;
        }

        public async Task<IEnumerable<PontosPessoa>> ConsultarPontos(Pessoa pessoa)
        {
            Stopwatch watch = Stopwatch.StartNew();
            _Logger.LogInformation($"Iniciando a execução do método ConsultarPontos({pessoa})");
            var result = await _Inner.ConsultarPontos(pessoa);
            watch.Stop(); 
            _Logger.LogInformation($"Encerrando a execução do método ConsultarPontos({pessoa}) {watch.ElapsedMilliseconds}ms");
            return result;
        }
    }
}