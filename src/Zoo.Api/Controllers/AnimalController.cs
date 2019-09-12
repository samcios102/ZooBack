using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zoo.Application.Commands;
using Zoo.Application.Commands.Animals;
using Zoo.Application.Dto;
using Zoo.Application.Queries;
using Zoo.Application.Queries.Animals;

namespace Zoo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public AnimalController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalDto>> GetByIdAsync([FromRoute] Guid id)
        {
            var result = await _queryDispatcher.DispatchAsync<GetAnimal, AnimalDto>(new GetAnimal(id));

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> SearchAsync([FromQuery] SearchAnimals query)
        {
            var result = await _queryDispatcher.DispatchAsync<SearchAnimals, IEnumerable<AnimalDto>>(query);

            if (result is null || !result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimalAsync([FromBody] CreateAnimal command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(GetByIdAsync), new {id = command.Id}, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DeleteAnimalAsync([FromRoute] Guid id, [FromBody] UpdateAnimal command)
        {
            command.Bind(x => x.Id, id);

            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalAsync([FromRoute] Guid id)
        {
            await _commandDispatcher.DispatchAsync(new DeleteAnimal(id));
            
            return Ok();
        }


    }
}