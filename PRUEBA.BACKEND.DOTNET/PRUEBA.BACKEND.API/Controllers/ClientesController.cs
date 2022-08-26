using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRUEBA.BACKEND.APPLICATION.CustomExceptions;
using PRUEBA.BACKEND.APPLICATION.DTOs;
using PRUEBA.BACKEND.APPLICATION.Interfaces;
using PRUEBA.BACKEND.DOMAIN.DTOs;

namespace PRUEBA.BACKEND.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesAppService clientesAppService;

        public ClientesController(IClientesAppService clientesAppService)
        {
            this.clientesAppService = clientesAppService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(clientesAppService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrio un error interno: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Crear(ClientRequestAppDto Model)
        {
            try
            {
                CreatedClientResponseAppDto Cliente = await clientesAppService.Crear(Model);
                return Accepted(Cliente);
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(long id, ClientRequestAppDto Model)
        {
            try
            {
                await clientesAppService.Actualizar(id, Model);
                return NoContent();
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(long id)
        {
            try
            {
                await clientesAppService.Eliminar(id);
                return NoContent();
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
