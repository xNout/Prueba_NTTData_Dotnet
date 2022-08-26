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
    public class CuentasController : ControllerBase
    {
        private readonly ICuentasAppService cuentasAppService;

        public CuentasController(ICuentasAppService cuentasAppService)
        {
            this.cuentasAppService = cuentasAppService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(cuentasAppService.GetAllDtos());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrio un error interno: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Crear(CuentaRequestAppDto Model)
        {
            try
            {
                Cuenta cuenta = await cuentasAppService.Crear(Model);
                return Accepted(cuenta);
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
        public async Task<IActionResult> Actualizar(long id, CuentaRequestAppDto Model)
        {
            try
            {
                await cuentasAppService.Actualizar(id, Model);
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
