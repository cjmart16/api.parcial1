﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;

namespace api.examenparcial1.Controllers
{
    public class FacturaControlador : Controller
    {
        private IConfiguration configuration;
        private FacturaRepository facturaRepository;

        /*public FacturaController()*/
        public FacturaControlador(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.facturaRepository = new FacturaRepository(configuration.GetConnectionString("postgresDB"));
        }
        // Generate crud controller
        [HttpPost]
        [Route("agregar")]
        public IActionResult add(FacturaModel factura)
        {
            try
            {
                if (facturaRepository.add(factura))
                    return Ok("Factura Agregada Exitosamente");
                else
                    return BadRequest("No se pudo agregar la Factura");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("modificar")]
        public IActionResult update(FacturaModel factura)
        {
            try
            {
                if (facturaRepository.update(factura))
                    return Ok("Factura Actualizada");
                else
                    return BadRequest("Error al Actualizar Factura");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("eliminar")]
        public IActionResult remove(int id)
        {
            try
            {
                if (facturaRepository.remove(id))
                    return Ok("Factura Eliminada");
                else
                    return BadRequest("No se pudo eliminar la Factura");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("consultar/{id}")]
        public IActionResult get(int id)
        {
            try
            {
                var factura = facturaRepository.get(id);
                if (factura != null)
                    return Ok(factura);
                else
                    return BadRequest("Factura no Encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("lista")]
        public IActionResult list()
        {
            try
            {
                var facturas = facturaRepository.list();
                if (facturas != null)
                    return Ok(facturas);
                else
                    return BadRequest("No existen Facturas Registradas");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
