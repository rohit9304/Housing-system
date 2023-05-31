using Housing_system.DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Housing_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
