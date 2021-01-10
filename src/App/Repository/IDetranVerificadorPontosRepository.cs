using DesignPatternSamples.App.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.App.Repository
{
    public interface IDetranVerificadorPontosRepository
    {
        Task<IEnumerable<PontosPessoa>> ConsultarPontos(Pessoa pessoa);
    }
}
