using Intuit.Application.DTOs.Cliente;
using Intuit.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intuit.Api.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _clienteService.GetByIdAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _clienteService.GetAllAsync();

            return Ok(response);
        }

        [HttpGet("search/{text}")]
        public async Task<IActionResult> SearchByName(string text)
        {
            var response = await _clienteService.SearchAsync(text);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteRequestDto payload)
        {
            var response = await _clienteService.CreateAsync(payload);

            return Created(string.Empty, response);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClienteRequestDto payload)
        {
            var response = await _clienteService.UpdateAsync(payload);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteService.DeleteAsync(id);

            return Ok("Se ha eliminado correctamente.");
        }
    }
}
