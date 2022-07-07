using Microsoft.AspNetCore.Mvc;

namespace FoodService.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
