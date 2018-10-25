using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using moneygoes.Models;
using moneygoes.Models.DTOs;
using moneygoes.Models.ViewModels;
using moneygoes.Services;

namespace moneygoes.Controllers
{
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly MongoRepository _repository;
        private readonly ILogger _logger;
        public PaymentsController(MongoRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _repository.All<PaymentGroup>();
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                const string error = "Could not get all groups";
                _logger.LogError(ex, error);
                return StatusCode(500, Error.GetError(500, error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup([FromBody] PaymentGroupVM data)
        {
            if (!ModelState.IsValid) {
                return BadRequest(Error.GetError(400, ModelState.Values.Select(v => v.Errors)));
            }
            try
            {
                // TODO: return an object;
                // TODO: add mapping;
                await _repository.Add(data);
            }
            catch (System.Exception ex)
            {
                const string error = "Could not add new group";
                _logger.LogError(ex, error);
                return StatusCode(500, Error.GetError(500, error));
            }
            // TODO: Make Created();
            return NoContent();
        }
    }
}