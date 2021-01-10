using AutoMapper;
using DesignPatternSamples.App.DTO;
using DesignPatternSamples.WebAPI.Models.Detran;

namespace DesignPatternSamples.WebAPI.Mapper
{
    public class DetranMapper : Profile
    {
        public DetranMapper()
        {
            CreateMap<CadastroPessoa, Pessoa>();
            CreateMap<PontosPessoa, PontosCadastroPessoa>();
        }
    }
}
