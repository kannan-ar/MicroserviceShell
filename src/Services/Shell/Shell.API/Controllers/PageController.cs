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
    public class PageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPageService _pageService;

        public PageController(IMapper mapper, IPageService pageService)
        {
            _mapper = mapper;
            _pageService = pageService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Models.DTOs.PageMetaData>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<Models.DTOs.PageMetaData>>(await _pageService.GetAllAsync().ConfigureAwait(false)));
        }

        [HttpGet("IsExists/{pageName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Models.DTOs.PageMetaData>>> Get(string pageName)
        {
            return Ok(await _pageService.IsPageExists(pageName));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(Models.DTOs.PageMetaData metaData)
        {
            await _pageService.AddPage(_mapper.Map<Models.Entities.PageMetaData>(metaData));
            return CreatedAtAction(nameof(Get), new { pageName = metaData.PageName });
        }
    }
}
