using ClientesAPI.DTOs;
using ClientesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clientesList = await _service.GetAll();
            if (clientesList is null)
            {
                return NotFound("Nenhum cliente encontrado");
            }

            return Ok(clientesList);

        }

        [HttpGet("{id:int}", Name = "GetClient")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClient(int id)
        {
            var cliente = await _service.GetById(id);
            if (cliente is null)
            {
                return NotFound("O cliente não foi encontrado");
            }

            return Ok(cliente);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO cliente)
        {
            if (cliente is null)
            {
                return BadRequest("Cliente inválido");
            }

            await _service.Add(cliente);

            return new CreatedAtRouteResult("GetClient", new { id = cliente.Id }, cliente);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO cliente)
        {
            if (cliente is null)
            {
                return BadRequest();
            }

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            await _service.Update(cliente);
            return Ok(cliente);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ClienteDTO>> Delete(int id)
        {
            var cliente = await _service.GetById(id);
            if (cliente is null)
            {
                return NotFound("Cliente não encontrado");
            }

            await _service.Remove(id);
            return Ok(cliente);
        }
    }
}
