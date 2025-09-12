using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Application.Services;

namespace SalesDatePrediction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly ApplicationServices _applicationServices;

        public SystemController(ApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpGet("ClientOrders/{id:int}")]
        public async Task<IActionResult> GetClientOrders([FromRoute] int id)
        {
            return Ok(await _applicationServices.GetClientOrders(id));
        }

        [HttpGet("Employees")]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _applicationServices.GetEmployees());
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _applicationServices.GetProducts());
        }

        [HttpGet("Shippers")]
        public async Task<IActionResult> GetShippers()
        {
            return Ok(await _applicationServices.GetShippers());
        }

        [HttpGet("Predictions")]
        public async Task<IActionResult> GetPredictions()
        {
            return Ok(await _applicationServices.GetPredictions());
        }

        [HttpPost("Orders")]
        public async Task<IActionResult> CreateOrder([FromBody] NewOrderDTO newOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid order");
            }

            return Ok(await _applicationServices.CreateOrder(newOrder));
        }
    }
}
