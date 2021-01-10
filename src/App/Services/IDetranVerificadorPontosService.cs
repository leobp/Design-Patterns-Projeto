using DesignPatternSamples.App.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.App.Services
{
    public interface IDetranVerificadorPontosService
    {
        Task<IEnumerable<PontosPessoa>> ConsultarPontos(Pessoa pessoa);
    }
}
