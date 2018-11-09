using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using moneygoes.Models;
using moneygoes.Models.DTOs;
using moneygoes.Models.ViewModels;
using moneygoes.Services.DB;

namespace moneygoes.Controllers
{
    public abstract class GenericController<E, D, V, R> : ControllerBase
            where E : BaseEntity
            where D : BaseDto
            where V : IViewModel
            where R : IRepository<E>
    {
        protected readonly R _repository;
        protected readonly string _;

        private readonly ILogger _logger;

        public GenericController(R repository, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _ = GetType().Name;
            _logger = loggerFactory.CreateLogger(_);
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetItems()
        {
            var data = await _repository.GetItemsAsync();
            var result = Mapper.Map<IEnumerable<D>>(data);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetItemByID(int id)
        {
            var data = await _repository.GetItemByIDAsync(id);
            if (data == null)
                return NotFound();
            var result = Mapper.Map<D>(data);
            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> AddItem([FromBody] V vm)
        {
            if (vm == null || !ModelState.IsValid)
                return BadRequest();
            var result = Mapper.Map<E>(vm);
            await _repository.AddItemAsync(result);
            if (!await _repository.SaveAsync())
                return StatusCode(500, $"Could not create {_}'s record");
            var resultDto = Mapper.Map<D>(result);
            return CreatedAtAction("GetItemByID", new { id = resultDto.ID }, resultDto);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateItem(int id,
            [FromBody] D dto)
        {
            if (dto == null || !ModelState.IsValid)
                return BadRequest();
            var entity = await _repository.GetItemByIDAsync(id);
            if (entity == null)
                return NotFound();
            Mapper.Map(dto, entity);
            if (!await _repository.SaveAsync())
                return StatusCode(500, $"Could not update {_}'s record");
            return NoContent();
        }

        [HttpPatch("{id}")]
        public virtual async Task<IActionResult> UpdateClinics(
            int id,
            [FromBody] JsonPatchDocument<D> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();
            var entity = await _repository.GetItemByIDAsync(id);
            if (entity == null)
                return NotFound();

            var dto = Mapper.Map<D>(entity);
            patchDoc.ApplyTo(dto, ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Mapper.Map(dto, entity);
            if (!await _repository.SaveAsync())
                return StatusCode(500, $"Could not patch {_}'s record");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteItems(int id)
        {
            var entity = await _repository.GetItemByIDAsync(id);
            if (entity == null)
                return NotFound();
            await _repository.RemoveItemAsync(entity);
            if (!await _repository.SaveAsync())
                return StatusCode(500, $"Could not remove {_}'s record");
            return NoContent();
        }
    }
}