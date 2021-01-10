using DesignPatternSamples.App.DTO;
using DesignPatternSamples.App.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using Workbench.IDistributedCache.Extensions;

namespace DesignPatternSamples.App.Decorators
{
    public class DetranVerificadorPontosDecoratorCache : IDetranVerificadorPontosService
    {
        private readonly IDetranVerificadorPontosService _Inner;
        private readonly IDistributedCache _Cache;

        public DetranVerificadorPontosDecoratorCache(
            IDetranVerificadorPontosService inner,
            IDistributedCache cache)
        {
            _Inner = inner;
            _Cache = cache;
        }

        public Task<IEnumerable<PontosPessoa>> ConsultarPontos(Pessoa pessoa)
        {
            return Task.FromResult(_Cache.GetOrCreate($"{pessoa.UF}_{pessoa.CPF}", () => _Inner.ConsultarPontos(pessoa).Result));
        }
    }
}