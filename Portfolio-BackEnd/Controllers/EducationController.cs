using Data.ViewModels.Education.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Portfolio_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult AddEducation([FromBody] EducationViewModel education)
        {
            var result = _educationService.AddEducation(education);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        [Authorize]
        public IActionResult UpdateEducation([FromBody] EducationViewModel education)
        {
            var result = _educationService.UpdateEducation(education);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public IActionResult DeleteEducation(int id)
        {
            var result = _educationService.DeleteEducation(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public IActionResult GetEducation(int id)
        {
            var result = _educationService.GetEducation(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetEducations()
        {
            var result = _educationService.GetEducations();

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}