using Housing_system.BussinessLayer.DTO;
using Housing_system.BussinessLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Housing_system.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public IActionResult GetAllProperties()
        {
            var properties = _propertyService.GetAllProperties();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public IActionResult GetPropertyById(int id)
        {
            var property = _propertyService.GetPropertyById(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }

        [HttpPost("add")]
        public IActionResult CreateProperty(PropertyDto propertyDto)
        {
            _propertyService.CreateProperty(propertyDto);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(int id)
        {
            _propertyService.DeleteProperty(id);
            return NoContent();
        }
    }

}
