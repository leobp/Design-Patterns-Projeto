using System;

namespace DesignPatternSamples.WebAPI.Models.Detran
{
    public class PontosCadastroPessoa
    {
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public double Pontos { get; set; }
    }
}