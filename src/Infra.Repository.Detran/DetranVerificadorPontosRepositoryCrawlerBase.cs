using DesignPatternSamples.App.DTO;
using DesignPatternSamples.App.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public abstract class DetranVerificadorPontosRepositoryCrawlerBase : IDetranVerificadorPontosRepository
    {
        public async Task<IEnumerable<PontosPessoa>> ConsultarPontos(Pessoa pessoa)
        {
            var html = await RealizarAcesso(pessoa);
            return await PadronizarResultado(html);
        }

        protected abstract Task<string> RealizarAcesso(Pessoa pessoa);
        protected abstract Task<IEnumerable<PontosPessoa>> PadronizarResultado(string html);
    }
}
