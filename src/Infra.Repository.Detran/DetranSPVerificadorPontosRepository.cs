using DesignPatternSamples.App.DTO;
using DesignPatternSamples.App.Repository;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranSPVerificadorPontosRepository : IDetranVerificadorPontosRepository
    {
        private readonly ILogger _Logger;

        public DetranSPVerificadorPontosRepository(ILogger<DetranSPVerificadorPontosRepository> logger)
        {
            _Logger = logger;
        }

        public Task<IEnumerable<PontosPessoa>> ConsultarPontos(Pessoa pessoa)
        {
            _Logger.LogDebug($"Consultando pontos na carteira da pessoa fisica  {pessoa.CPF} para o estado de SP.");
            return Task.FromResult<IEnumerable<PontosPessoa>>(new List<PontosPessoa>() { new PontosPessoa() });
        }
    }
}
