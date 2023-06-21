using ClubNautico.DTO;
using ClubNautico.Models;
using ClubNautico.Services.Socios.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ClubNautico.Service.Socios.Queries.GetAllSocios;
using static ClubNautico.Services.Socios.Commands.SaveSocio;
using static ClubNautico.Services.Socios.Queries.GetSocioById;

namespace ClubNautico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocioController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hola mundo");
        }

        [HttpGet] //TODO: CREAMOS UN METODO GET PARA OBTENER UN SOCIO POR ID
        [Route("obtenerSocio/{id}")] //TODO: DEFINIMOS LA RUTA DEL METODO
        public async Task<SocioDTO> GetSocioById(int id) //TODO: EL METODO RECIBE UN ID
        {
            var socio = await _mediator.Send(new GetSocioByIdQuery { Id = id }); //TODO: ENVIAMOS EL ID AL HANDLER
            return socio; //TODO: RETORNAMOS EL SOCIO

           
        }

        [HttpGet]
        [Route("obtenerSocios")]
        public async Task<List<SocioDTO>> GetAllSocios()
        {
            var socios = await _mediator.Send(new GetAllSociosQuery());
            return socios;
        }


        [HttpPost] //TODO: CREAMOS UN METODO POST PARA CREAR UN SOCIO
        [Route("crearSocio")] //TODO: DEFINIMOS LA RUTA DEL METODO
        public async Task<IActionResult> CreateSocio([FromBody] SaveSocioCommand socio) //TODO: EL METODO RECIBE UN SOCIO
        {
            var socioCreado = await _mediator.Send(socio); //TODO: ENVIAMOS EL SOCIO AL HANDLER
            return Ok(socioCreado); //TODO: RETORNAMOS EL SOCIO CREADO
        }



    }
}
