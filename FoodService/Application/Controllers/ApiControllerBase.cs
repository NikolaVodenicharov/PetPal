using Microsoft.AspNetCore.Mvc;

namespace FoodService.Application.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
