using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pdbc.Shopping.Api.Contracts.Requests.Health;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.Api.Common.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ShoppingBaseController
    {
        private readonly IHealthCheckCqrsService _healthCheckCqrsService;

        public HealthController(IHealthCheckCqrsService healthCheckCqrsService)
        {
            _healthCheckCqrsService = healthCheckCqrsService;
        }


        [HttpGet(Name = nameof(LifelineCheck))]
        public async Task<ActionResult<String>> LifelineCheck()
        {
            var response = await _healthCheckCqrsService.LifelineCheck(new LifelineCheckRequest());
            return Ok(response);
        }
    }
}
