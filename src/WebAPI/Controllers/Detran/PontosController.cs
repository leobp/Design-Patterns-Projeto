using AutoMapper;
using DesignPatternSamples.App.DTO;
using DesignPatternSamples.App.Services;
using DesignPatternSamples.WebAPI.Models;
using DesignPatternSamples.WebAPI.Models.Detran;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.WebAPI.Controllers.Detran
{
    [Route("api/Detran/[controller]")]
    [ApiController]
    public class PontosController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IDetranVerificadorPontosService _DetranVerificadorPontosServices;

        public PontosController(IMapper mapper, IDetranVerificadorPontosService detranVerificadorPontosServices)
        {
            _Mapper = mapper;
            _DetranVerificadorPontosServices = detranVerificadorPontosServices;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(SuccessResultModel<IEnumerable<PontosCadastroPessoa>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get([FromQuery]CadastroPessoa pessoa)
        {
            var pontos = await _DetranVerificadorPontosServices.ConsultarPontos(_Mapper.Map<Pessoa>(pessoa));

            var result = new SuccessResultModel<IEnumerable<PontosCadastroPessoa>>(_Mapper.Map<IEnumerable<PontosCadastroPessoa>>(pontos));

            return Ok(result);
        }
    }
}