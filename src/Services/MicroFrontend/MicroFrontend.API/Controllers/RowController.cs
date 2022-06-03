﻿using MicroFrontend.API.Models.DTOs;
using MicroFrontend.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroFrontend.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class RowController : ControllerBase
    {
        private readonly IRowService _rowService;

        public RowController(IRowService rowService)
        {
            this._rowService = rowService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Row>>> Get()
        {
            return Ok(await _rowService.GetAsync());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(Row row)
        {
            await _rowService.AddRow(row);
            return CreatedAtAction(nameof(Get), new { index = row.RowIndex });
        }
    }
}
