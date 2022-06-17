using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shell.API.Models.DTOs;
using Shell.API.Models.Entities;
using Shell.API.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shell.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPageService _pageService;

        public PageController(IMapper mapper, IPageService pageService)
        {
            _mapper = mapper;
            _pageService = pageService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.DTOs.PageMetaData>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<Models.DTOs.PageMetaData>>(await _pageService.GetAllAsync().ConfigureAwait(false)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(Models.DTOs.PageMetaData metaData)
        {
            await _pageService.AddPage(_mapper.Map<Models.Entities.PageMetaData>(metaData));
            return CreatedAtAction(nameof(Get), new { pageName = metaData.PageName });
        }
    }
}
