using System;

namespace DesignPatternSamples.App.Repository
{
    public interface IDetranVerificadorPontosFactory
    {
        public IDetranVerificadorPontosFactory Register(string UF, Type repository);
        public IDetranVerificadorPontosRepository Create(string UF);
    }
}
