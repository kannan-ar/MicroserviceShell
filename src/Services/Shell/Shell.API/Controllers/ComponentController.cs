using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shell.API.Domain.Services;
using Shell.API.Models.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shell.API.Controllers
{
    [Authorize(Policy = "ComponentPolicy")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly IMapper _mapper;
        private readonly IValidator<Component> _validator;
        private readonly IComponentService _componentService;

        public ComponentController(
            IHttpContextAccessor httpContextAccesor,
            IMapper mapper, 
            IValidator<Component> validator, 
            IComponentService componentService)
        {
            _httpContextAccesor = httpContextAccesor;
            _mapper = mapper;
            _validator = validator;
            _componentService = componentService;
        }

        [AllowAnonymous]
        [HttpGet("components")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ComponentBase>>> Get()
        {
            var isAuthenticated = _httpContextAccesor.HttpContext.User.Identity.IsAuthenticated;

            return Ok(_mapper.Map<IEnumerable<ComponentBase>>(await _componentService.GetComponentsAsync(isAuthenticated).ConfigureAwait(false)));
        }

        [HttpGet("components/{componentName}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Component>> Get(string componentName)
        {
            if(!await _componentService.IsComponentExistsAsync(componentName))
            {
                return NotFound(componentName);
            }

            return Ok(_mapper.Map<Component>(await _componentService.GetComponentAsync(componentName).ConfigureAwait(false)));
        }

        [HttpPost("components")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(Component component)
        {
            ValidationResult result = await _validator.ValidateAsync(component);

            if(!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage));
            }

            await _componentService.InsertComponentAsync(_mapper.Map<Models.Entities.Component>(component));
            return NoContent();
        }

        [HttpPatch("components/{componentName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch(string componentName, Component component)
        {
            if (!await _componentService.IsComponentExistsAsync(componentName))
            {
                return BadRequest($"{componentName} is not exists");
            }

            await _componentService.UpdateComponent(componentName, _mapper.Map<Models.Entities.Component>(component));
            return NoContent();
        }

        [HttpDelete("components/{componentName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string componentName)
        {
            if (!await _componentService.IsComponentExistsAsync(componentName))
            {
                return BadRequest($"{componentName} is not exists");
            }

            await _componentService.DeleteComponentAsync(componentName);
            return NoContent();
        }
    }
}
