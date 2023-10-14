using Data.ViewModels.Framework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Portfolio_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworkController : ControllerBase
    {
        private readonly IFrameworkService _languageService;

        public FrameworkController(IFrameworkService languageService)
        {
            _languageService = languageService;
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult AddFramework([FromBody] FrameworkViewModel language)
        {
            var result = _languageService.AddFramework(language);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Data);
        }

        [HttpPut("update")]
        [Authorize]
        public IActionResult UpdateFramework([FromBody] FrameworkViewModel language)
        {
            var result = _languageService.UpdateFramework(language);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Data);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public IActionResult DeleteFramework(int id)
        {
            var result = _languageService.DeleteFramework(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Data);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public IActionResult GetFramework(int id)
        {
            var result = _languageService.GetFramework(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Data);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetFrameworks()
        {
            var result = _languageService.GetFrameworks();

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Data);
        }
    }
}