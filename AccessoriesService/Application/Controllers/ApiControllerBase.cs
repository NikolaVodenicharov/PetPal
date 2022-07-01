using Microsoft.AspNetCore.Mvc;

namespace AccessoriesService.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
