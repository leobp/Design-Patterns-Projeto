using DesignPatternSamples.App.DTO;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranRJVerificadorPontosRepository : DetranVerificadorPontosRepositoryCrawlerBase
    {
        private readonly ILogger _Logger;

        public DetranRJVerificadorPontosRepository(ILogger<DetranRJVerificadorPontosRepository> logger)
        {
            _Logger = logger;
        }

        protected override Task<IEnumerable<PontosPessoa>> PadronizarResultado(string html)
        {
            _Logger.LogDebug($"Padronizando o Resultado {html}.");
            return Task.FromResult<IEnumerable<PontosPessoa>>(new List<PontosPessoa>() { new PontosPessoa() });
        }

        protected override Task<string> RealizarAcesso(Pessoa pessoa)
        {
            _Logger.LogDebug($"Consultando pontos na carteira da pessoa fisica {pessoa.CPF} para o estado de RJ.");
            return Task.FromResult("CONTEUDO DO SITE DO DETRAN/RJ");
        }
    }
}
