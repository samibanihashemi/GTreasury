using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetPresentValue.UI.Controllers.Model;
using Serilog;

namespace NetPresentValue.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculatorService _service;
        private readonly ILogger _logger;

        public CalculateController(ICalculatorService service, ILogger logger)
        {
            _service = service;
            _logger = logger;

        }

        // POST api/Calculate
        [HttpPost]
        public async Task<ActionResult<IEnumerable<dynamic>>> Post([FromBody] ApiParamsModel apiParamsModel)
        {
            try
            {
                var result = await _service.GetCalculatedResult(apiParamsModel);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}