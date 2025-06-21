using ClientesAPI.DTOs;
using ClientesAPI.Integration.ViaCepAPI.Refit;
using ClientesAPI.Integration.ViaCepAPI.Response;
using ClientesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClientesAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _service;
        private readonly IViaCep _viaCep;
        public EnderecoController(IEnderecoService service, IViaCep viaCep)
        {
            _service = service;
            _viaCep = viaCep;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> Get()
        {
            var enderecosList = await _service.GetAll();
            if (enderecosList is null)
            {
                return NotFound("Nenhum endereço encontrado");
            }

            return Ok(enderecosList);

        }

        [HttpGet("{id:int}", Name = "GetAddress")]
        public async Task<ActionResult<IEnumerable<ContatoDTO>>> GetAddress(int id)
        {
            var endereco = await _service.GetById(id);
            if (endereco is null)
            {
                return NotFound("O endereço não foi encontrado");
            }

            return Ok(endereco);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] string cep, [FromForm] string numero)
        {
            if (cep is null || numero is null)
            {
                return BadRequest("Endereço inválido");
            }

            var dadosCep = await _viaCep.GetByCep(cep);

            if(dadosCep is null)
            {
                return BadRequest("CEP inválido");
            }

            var endereco = new EnderecoDTO
            {
                Cep = dadosCep.Cep,
                Logradouro = dadosCep.Logradouro,
                Cidade = dadosCep.Localidade,
                Numero = numero,
                Complemento = dadosCep.Complemento
            };

            await _service.Add(endereco);
            return new CreatedAtRouteResult("GetAddress", new { id = endereco.Id }, endereco);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] EnderecoDTO endereco)
        {
            if (endereco is null)
            {
                return BadRequest();
            }

            if(id != endereco.Id)
            {
                return BadRequest();
            }

            var dadosCep = await _viaCep.GetByCep(endereco.Cep);

            if (dadosCep is null)
            {
                return BadRequest("CEP inválido");
            }

            var novoEndereco = new EnderecoDTO
            {
                Cep = dadosCep.Cep,
                Logradouro = dadosCep.Logradouro,
                Cidade = dadosCep.Localidade,
                Numero = endereco.Numero,
                Complemento = dadosCep.Complemento
            };

            await _service.Add(novoEndereco);
            return new CreatedAtRouteResult("GetAddress", new { id = endereco.Id }, endereco);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ContatoDTO>> Delete(int id)
        {
            var endereco = await _service.GetById(id);
            if (endereco is null)
            {
                return NotFound("Endereço não encontrado");
            }

            await _service.Remove(id);
            return Ok(endereco);
        }
    }
}
