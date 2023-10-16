using Data.ViewModels.Work.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Portfolio_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult AddWork([FromBody] WorkViewModel work)
        {
            var result = _workService.AddWork(work);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        [Authorize]
        public IActionResult UpdateWork([FromBody] WorkViewModel work)
        {
            var result = _workService.UpdateWork(work);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public IActionResult DeleteWork(int id)
        {
            var result = _workService.DeleteWork(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public IActionResult GetWork(int id)
        {
            var result = _workService.GetWork(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetWorks()
        {
            var result = _workService.GetWorks();

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}