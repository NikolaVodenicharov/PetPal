using FoodService.Application.Queries.FoodDetails;
using FoodService.Application.Queries.FoodSummary;
using FoodService.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FoodService.Application.Controllers
{
    public class FoodController : ApiControllerBase
    {
        private readonly IFoodRepository repository;
        private readonly FoodSummaryAllHandler foodSummaryHandler;
        private readonly FoodDetailsHandler foodDetailsHandler;

        public FoodController(IFoodRepository repository, FoodSummaryAllHandler foodSummaryHandler, FoodDetailsHandler foodDetailsHandler)
        {
            this.repository = repository;
            this.foodSummaryHandler = foodSummaryHandler;
            this.foodDetailsHandler = foodDetailsHandler;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> All()
        {
            var result = await this.foodSummaryHandler.Handle();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> ById (int id)
        {
            var result = await this.foodDetailsHandler.Handle(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
