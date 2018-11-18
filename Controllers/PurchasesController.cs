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
using moneygoes.Services.DB;

namespace moneygoes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PurchasesController
        : GenericController<PurchasingGroup, PurchasingGroupDto, PurchasingGroupVM, IPaymentGroupRepo>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public PurchasesController(
            UserManager<AppUser> userManager,
            IMapper mapper,
            IPaymentGroupRepo repository,
            ILoggerFactory loggerFactory) : base(repository, loggerFactory)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public override async Task<IActionResult> GetItems()
        {
            return Ok();
        }
    }
}