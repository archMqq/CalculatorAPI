using CalculatorAPI.Service;
using CalculatorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationController : Controller
    {
        private readonly ICalculationService _calculatorService;
        public CalculationController(ICalculationService calculationService)
        {
            _calculatorService = calculationService;
        }

        [HttpGet]
        [Route("add")]
        public ActionResult<CalculationResult> Add(double a, double b)
        {
            return new CalculationResult() { Result = _calculatorService.Add(a, b) };
        }

        [HttpGet]
        [Route("diff")]
        public ActionResult<CalculationResult> Diff(double a, double b)
        {
            return new CalculationResult() { Result = _calculatorService.Diff(a, b) };
        }

        [HttpGet]
        [Route("div")]
        public ActionResult<CalculationResult> Div(double a, double b)
        {
            return new CalculationResult() { Result = _calculatorService.Div(a, b) };
        }

        [HttpGet]
        [Route("multi")]
        public ActionResult<CalculationResult> Multi(double a, double b)
        {
            return new CalculationResult() { Result = _calculatorService.Multi(a, b) };
        }

        [HttpGet]
        [Route("pow")]
        public ActionResult<CalculationResult> Pow(double numb, double degree)
        {
            return new CalculationResult() { Result = _calculatorService.Pow(numb, degree) };
        }

        [HttpGet]
        [Route("root")]
        public ActionResult<CalculationResult> Root(double numb, double degree)
        {
            return new CalculationResult() { Result = _calculatorService.Root(numb, degree) };
        }

        [HttpPost]
        [Route("calculate")]
        public ActionResult<CalculationResult> ExpressionSubstract([FromBody] string expression)
        {
            var result = _calculatorService.ExpressionSubstract(expression);

            if (result.Error is not null)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
