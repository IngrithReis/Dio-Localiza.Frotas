using Localiza.Frotas.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Dio_Localiza.Frotas.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;
        public VeiculosController(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Veiculo>>> GetAll([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
           return Ok(await _veiculoRepository.GetAll(pagina,quantidade));
        }

        [HttpGet("{id:Guid}")]
        public async Task <ActionResult<Veiculo>> Get(Guid id)
        {
            var veiculo = await _veiculoRepository.GetbyId(id);

            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Veiculo veiculo)
        {
            await _veiculoRepository.Add(veiculo);
            return CreatedAtAction(nameof(Get), new { veiculo.Id }, veiculo);
        }

        [HttpPut("{id:Guid}")]
        public async  Task<IActionResult> Put(Guid id, [FromBody] Veiculo veiculo)

        {
            if (await _veiculoRepository.GetbyId(id) == null)
            {
                return NotFound("Id não localizado!");
            }

           await _veiculoRepository.Update(veiculo);

            return NoContent();

        }
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var veiculo = await _veiculoRepository.GetbyId(id);

            if (veiculo == null)
            {
                return NotFound("Veículo não localizado!");
            }
            await _veiculoRepository.Delete(veiculo);
            return NoContent();

        }
    }
}
