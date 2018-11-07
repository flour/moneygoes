using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using moneygoes.Models;
using moneygoes.Models.DTOs;
using moneygoes.Models.ViewModels;
using moneygoes.Services;

namespace moneygoes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly MongoRepository _repository;
        private readonly IMapper _mapper;

        private readonly ILogger _logger;
        public PaymentsController(UserManager<AppUser> userManager, MongoRepository repository, IMapper mapper, ILogger logger)
        {
            _userManager = userManager;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allGroups = await _repository.All<PaymentGroup>();
                var result = _mapper.Map<IEnumerable<PaymentsGroupDto>>(allGroups);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                const string error = "Could not get all groups";
                _logger.LogError(ex, error);
                return StatusCode(500, Error.GetError(500, error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOne(string id)
        {
            try
            {
                var result = await _repository.Single<PaymentGroup>(id);
                return Ok(_mapper.Map<PaymentItemDto>(result));
            }
            catch (System.Exception ex)
            {
                var error = $"Could not get group by ID {id}";
                _logger.LogError(ex, error);
                return StatusCode(500, Error.GetError(404, error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup([FromBody] PaymentGroupVM data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Error.GetError(400, ModelState.Values.Select(v => v.Errors)));
            }
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var entity = _mapper.Map<PaymentGroup>(data);
                entity.UserId = user.Id;
                await _repository.Add(data);
                var newOne = _mapper.Map<PaymentsGroupDto>(await _repository.Single<PaymentGroup>("Name", data.Name));
                return Created($"api/payments/{newOne.Id}", newOne);
            }
            catch (System.Exception ex)
            {
                const string error = "Could not add new group";
                _logger.LogError(ex, error);
                return StatusCode(500, Error.GetError(500, error));
            }

        }
    }
}