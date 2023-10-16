using Data.ViewModels.Language.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Portfolio_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult AddLanguage([FromBody] LanguageViewModel language)
        {
            var result = _languageService.AddLanguage(language);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        [Authorize]
        public IActionResult UpdateLanguage([FromBody] LanguageViewModel language)
        {
            var result = _languageService.UpdateLanguage(language);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public IActionResult DeleteLanguage(int id)
        {
            var result = _languageService.DeleteLanguage(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public IActionResult GetLanguage(int id)
        {
            var result = _languageService.GetLanguage(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetLanguages()
        {
            var result = _languageService.GetLanguages();

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}