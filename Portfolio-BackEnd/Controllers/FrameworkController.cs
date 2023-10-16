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
        private readonly IFrameworkService _frameworkService;

        public FrameworkController(IFrameworkService frameworkService)
        {
            _frameworkService = frameworkService;
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult AddFramework([FromBody] FrameworkViewModel framework)
        {
            var result = _frameworkService.AddFramework(framework);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        [Authorize]
        public IActionResult UpdateFramework([FromBody] FrameworkViewModel framework)
        {
            var result = _frameworkService.UpdateFramework(framework);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public IActionResult DeleteFramework(int id)
        {
            var result = _frameworkService.DeleteFramework(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public IActionResult GetFramework(int id)
        {
            var result = _frameworkService.GetFramework(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetFrameworks()
        {
            var result = _frameworkService.GetFrameworks();

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}