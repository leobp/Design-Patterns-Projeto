using System.Threading.Tasks;

namespace DesignPatternSamples.Domain.Repository.Detran
{
    public interface IDetranVerificadorPontos
    {
        Task<PontosPessoa> ConsultarPontos(Pessoa pessoa);
    }
}
