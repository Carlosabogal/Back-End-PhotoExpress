
using Microsoft.AspNetCore.Mvc;
using ApiPhotoExpress.Model.DTO;
using ApiPhotoExpress.Model.Entity;
using ApiPhotoExpress.Service;
using Microsoft.AspNetCore.Cors;

namespace ApiPhotoExpress.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly RegisterService _registerService; 

        public RegisterController(RegisterService registerService)
        {
            _registerService = registerService ?? throw new ArgumentNullException(nameof(registerService));
        }

        [HttpPost("create")] 
        public async Task<IActionResult> CreateRegistro([FromBody] RegisterRequest request)
        {
            
            try
            {
                await _registerService.CreateRegister(request);
                return Ok("Register Created Sucessfull.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Problem to the moment of create reigster : {ex.Message}");
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetRegistros()
        {
            try
            {
                var registros = await _registerService.GetRegisters();
                return Ok(registros);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting records: {ex.Message}");
            }
        }
    }
}