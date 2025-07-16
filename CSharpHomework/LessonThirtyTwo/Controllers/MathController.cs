namespace LessonThirtyTwo.Controllers
{
    using LessonThirtyTwo.Services;
    using Microsoft.AspNetCore.Mvc;
    
    [ApiController]
    [Route("api/[controller]")]
    public class MathController : ControllerBase
    {
        private readonly IMathService _mathService;

        public MathController(IMathService mathService)
        {
            _mathService = mathService;
        }

        [HttpGet("add")]
        public IActionResult Add(int a, int b) => Ok(_mathService.Add(a, b));

        [HttpGet("subtract")]
        public IActionResult Subtract(int a, int b) => Ok(_mathService.Subtract(a, b));

        [HttpGet("multiply")]
        public IActionResult Multiply(int a, int b) => Ok(_mathService.Multiply(a, b));

        [HttpGet("divide")]
        public IActionResult Divide(int a, int b)
        {
            try
            {
                return Ok(_mathService.Divide(a, b));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
