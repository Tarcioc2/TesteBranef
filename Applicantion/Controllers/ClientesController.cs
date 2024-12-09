using Microsoft.AspNetCore.Mvc;
using Application.Commands.Cliente;
using Application.DTOs.Cliente;

namespace ClienteApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
        {
            var clientes = await _clienteService.GetClientesAsync();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CriarCliente(CriarClienteCommand command)
        {
            var id = await _clienteService.CriarClienteAsync(command);
            return CreatedAtAction(nameof(GetCliente), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetCliente(Guid id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(Guid id, AtualizarClienteCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _clienteService.AtualizarClienteAsync(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCliente(Guid id)
        {
            await _clienteService.DeletarClienteAsync(id);
            return NoContent();
        }
    }
}