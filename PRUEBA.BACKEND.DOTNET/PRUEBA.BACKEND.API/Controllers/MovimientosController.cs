using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRUEBA.BACKEND.APPLICATION.CustomExceptions;
using PRUEBA.BACKEND.APPLICATION.DTOs;
using PRUEBA.BACKEND.APPLICATION.Interfaces;
using PRUEBA.BACKEND.DOMAIN.Entities;

namespace PRUEBA.BACKEND.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientosAppService movimientosAppService;
        public MovimientosController(IMovimientosAppService movimientosAppService)
        {
            this.movimientosAppService = movimientosAppService;
        }
        [HttpGet("reporte/{IdCliente}")]
        public IActionResult Reporte(long IdCliente, string desde, string hasta)
        {
            try
            {
                return Accepted(movimientosAppService.Get(IdCliente, desde, hasta));
            }
            catch (ValidacionException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrio un error interno: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Crear(MovimientoRequestAppDto Model)
        {
            try
            {
                Movimiento movimiento = await movimientosAppService.Crear(Model);
                return Accepted(movimiento);
            }
            catch (ValidacionException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrio un error interno: {ex.Message}");
            }
        }
    }
}
