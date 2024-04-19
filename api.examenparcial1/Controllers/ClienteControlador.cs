using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;

namespace api.examenparcial1.Controllers
{
    public class ControladorCliente
        : Controller
    {
        private IConfiguration configuration;
        private ClienteRepository clienteRepository;

        /*public ClienteController()*/
        public ControladorCliente(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.clienteRepository = new ClienteRepository(configuration.GetConnectionString("postgresDB"));
        }
        // Generate crud controller
        [HttpPost]
        [Route("add")]
        public IActionResult add(ClienteModel cliente)
        {
            try
            {
                if (clienteRepository.add(cliente))
                    return Ok("Cliente Agregado Exitosamente");
                else
                    return BadRequest("No se pudo agregar al Cliente, verifique los errores");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult update(ClienteModel cliente, int id)
        {
            try
            {
                if (clienteRepository.update(cliente))
                    return Ok("Cliente Actualizado");
                else
                    return BadRequest("No se pudo actualizar Cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("remove")]
        public IActionResult remove(int id)
        {
            try
            {
                if (clienteRepository.remove(id))
                    return Ok("Cliente Eliminado");
                else
                    return BadRequest("No se pudo eliminar Cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("get/{id}")]
        public IActionResult get(int id)
        {
            try
            {
                var cliente = clienteRepository.get(id);
                if (cliente != null)
                    return Ok(cliente);
                else
                    return BadRequest("Cliente No Encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            try
            {
                var clientes = clienteRepository.list();
                if (clientes != null)
                    return Ok(clientes);
                else
                    return BadRequest("No Existen Clientes Registrados");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}