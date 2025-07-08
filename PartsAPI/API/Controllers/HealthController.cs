using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsAPI.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartsAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IHealthRepository _healthRepository;

        public HealthController(IHealthRepository healthRepository)
        {
            _healthRepository = healthRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHealth()
        {
            var canConnect = await _healthRepository.CanConnectToDatabaseAsync();
            return Ok(new { status = "OK", database = canConnect ? "Connected" : "Disconnected" });
        }
    }
}
