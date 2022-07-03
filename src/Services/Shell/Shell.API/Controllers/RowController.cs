using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shell.API.Domain.Services;
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

        [HttpGet("{pageName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            return CreatedAtAction(nameof(Get), new { pageName = row.PageName }, row);
        }

        [HttpPut("{pageName}/{rowIndex:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(string pageName, int rowIndex, Models.DTOs.Row row)
        {
            await _rowService.UpsertRow(pageName, rowIndex, _mapper.Map<Models.Entities.Row>(row));
            return NoContent();
        }

        [HttpPatch("{pageName}/{rowIndex:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch(string pageName, int rowIndex, Models.DTOs.Row row)
        {
            await _rowService.UpdateRow(pageName, rowIndex, _mapper.Map<Models.Entities.Row>(row));
            return NoContent();
        }

        [HttpDelete("{pageName}/{rowIndex:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string pageName, int rowIndex)
        {
            await _rowService.DeleteRow(pageName, rowIndex);
            return NoContent();
        }
    }
}
