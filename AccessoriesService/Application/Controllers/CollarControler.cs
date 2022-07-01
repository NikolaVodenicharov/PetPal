using AccessoriesService.Domain.Infrastructures;
using AccessoriesService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccessoriesService.Application.Controllers
{
    public class CollarControler : ApiControllerBase
    {
        private readonly ICollarRepository repository;

        public CollarControler(ICollarRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> All()
        {
            var collars = await repository.AllAsync();
            
            return Ok(collars);
        }

        [HttpPost]
        public IActionResult Create ([FromBody] Collar collar)
        {
            repository.Create(collar);

            return Ok();
        }
    }
}
