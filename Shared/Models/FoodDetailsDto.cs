using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class FoodDetailsDto : FoodSummaryDto
    {
        public FoodDetailsDto(int id, string? title, decimal sellPrice, string description) 
            : base(id, title, sellPrice)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}
