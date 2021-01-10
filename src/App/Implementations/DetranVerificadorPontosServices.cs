using DesignPatternSamples.App.DTO;
using DesignPatternSamples.App.Repository;
using DesignPatternSamples.App.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.App.Implementations
{
    public class DetranVerificadorPontosServices : IDetranVerificadorPontosService
    {
        private readonly IDetranVerificadorPontosFactory _Factory;

        public DetranVerificadorPontosServices(IDetranVerificadorPontosFactory factory)
        {
            _Factory = factory;
        }

        public Task<IEnumerable<PontosPessoa>> ConsultarPontos(Pessoa pessoa)
        {
            IDetranVerificadorPontosRepository repository = _Factory.Create(pessoa.UF);
            return repository.ConsultarPontos(pessoa);
        }
    }
}
