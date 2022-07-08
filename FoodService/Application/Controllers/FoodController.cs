using FoodService.Application.Queries.FoodDetails;
using FoodService.Application.Queries.FoodSummary;
using FoodService.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
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
        public async Task<ActionResult<IEnumerable<FoodSummaryDto>>> All()
        {
            var result = await this.foodSummaryHandler.Handle();

            if (result == null)
            {
                return NotFound();
            }

            var dtos = new List<FoodSummaryDto>(result.Count());
            foreach (var item in result)
            {
                dtos.Add(new FoodSummaryDto(item.Id, item.Title, item.SellPrice));
            }

            return Ok(dtos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<FoodDetailsDto>> Get (int id)
        {
            var result = await this.foodDetailsHandler.Handle(id);

            if (result == null)
            {
                return NotFound();
            }

            var details = new FoodDetailsDto(result.Id, result.Title, result.SellPrice, result.Description);

            return Ok(details);
        }
    }
}
