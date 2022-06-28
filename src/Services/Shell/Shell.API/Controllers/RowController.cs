using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shell.API.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class RowController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRowService _rowService;

        public RowController(IMapper mapper, IRowService rowService)
        {
            _mapper = mapper;
            _rowService = rowService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{pageName}")]
        public async Task<ActionResult<IEnumerable<Models.DTOs.Row>>> Get(string pageName)
        {
            return Ok(_mapper.Map<IEnumerable<Models.DTOs.Row>>(await _rowService.GetRowsByPageAsync(pageName)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(Models.DTOs.Row row)
        {
            await _rowService.InsertRow(_mapper.Map<Models.Entities.Row>(row));
            return CreatedAtAction(nameof(Get), new { pageName = row.PageName });
        }

        public async Task<IActionResult> Put(string pageName, int rowIndex, Models.DTOs.Row row)
        {
            return Ok();
        }
    }
}
