using ClientesAPI.DTOs;
using ClientesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _service;
        public ContatoController(IContatoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContatoDTO>>> Get()
        {
            var contatosList = await _service.GetAll();
            if (contatosList is null)
            {
                return NotFound("Nenhum contato encontrado");
            }

            return Ok(contatosList);

        }

        [HttpGet("{id:int}", Name = "GetContact")]
        public async Task<ActionResult<IEnumerable<ContatoDTO>>> GetContact(int id)
        {
            var contato = await _service.GetById(id);
            if (contato is null)
            {
                return NotFound("O contato não foi encontrado");
            }

            return Ok(contato);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContatoDTO contato)
        {
            if (contato is null)
            {
                return BadRequest("Contato inválido");
            }

            await _service.Add(contato);

            return new CreatedAtRouteResult("GetContact", new { id = contato.Id }, contato);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ContatoDTO contato)
        {
            if (contato is null)
            {
                return BadRequest();
            }

            if (id != contato.Id)
            {
                return BadRequest();
            }

            await _service.Update(contato);
            return Ok(contato);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ContatoDTO>> Delete(int id)
        {
            var contato = await _service.GetById(id);
            if (contato is null)
            {
                return NotFound("Contato não encontrado");
            }

            await _service.Remove(id);
            return Ok(contato);
        }

    }
}
