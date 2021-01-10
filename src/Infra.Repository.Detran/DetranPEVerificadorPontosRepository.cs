using DesignPatternSamples.App.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranPEVerificadorPontosRepository : DetranVerificadorPontosRepositoryCrawlerBase
    {
        private readonly ILogger _Logger;

        public DetranPEVerificadorPontosRepository(ILogger<DetranPEVerificadorPontosRepository> logger)
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
            Task.Delay(5000).Wait(); //Deixando o serviço mais lento para evidenciar o uso do CACHE.
            _Logger.LogDebug($"Consultando pontos na carteira da pessoa fisica {pessoa.CPF} para o estado de PE.");
            return Task.FromResult("CONTEUDO DO SITE DO DETRAN/PE");
        }
    }
}
