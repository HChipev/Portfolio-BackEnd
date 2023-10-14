using Data.ViewModels.Tool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Portfolio_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly IToolService _languageService;

        public ToolController(IToolService languageService)
        {
            _languageService = languageService;
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult AddTool([FromBody] ToolViewModel language)
        {
            var result = _languageService.AddTool(language);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Data);
        }

        [HttpPut("update")]
        [Authorize]
        public IActionResult UpdateTool([FromBody] ToolViewModel language)
        {
            var result = _languageService.UpdateTool(language);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Data);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public IActionResult DeleteTool(int id)
        {
            var result = _languageService.DeleteTool(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Data);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public IActionResult GetTool(int id)
        {
            var result = _languageService.GetTool(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Data);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetTools()
        {
            var result = _languageService.GetTools();

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Data);
        }
    }
}