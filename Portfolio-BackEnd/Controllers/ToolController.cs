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
        private readonly IToolService _toolService;

        public ToolController(IToolService toolService)
        {
            _toolService = toolService;
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult AddTool([FromBody] ToolViewModel tool)
        {
            var result = _toolService.AddTool(tool);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        [Authorize]
        public IActionResult UpdateTool([FromBody] ToolViewModel tool)
        {
            var result = _toolService.UpdateTool(tool);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public IActionResult DeleteTool(int id)
        {
            var result = _toolService.DeleteTool(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public IActionResult GetTool(int id)
        {
            var result = _toolService.GetTool(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetTools()
        {
            var result = _toolService.GetTools();

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}