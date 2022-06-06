namespace FoodService.Domain.Models
{
    /// <summary>
    /// Base class for all products, containing common logic for stocks that we want to sell.
    /// </summary>
    public class Product
    {
        public const int MaximumDescriptionLength = 1000;

        private string? title;
        private decimal avaragePurchasePricePerUnit;
        private decimal sellPrice;
        private decimal discountPercentage;
        private int quantity;
        private string? description;

        /// <param name="sellPrice">should be initialized after <paramref name="purchasePrice"/> because it is making validations based on it</param>
        /// <param name="discountPercentage">Could have default value of zeor if we dont want to have any initial discount. It should be initialized after <paramref name="purchasePrice"/> and <paramref name="sellPrice"/>, because it is making validations based on them</param>
        public Product(string title, decimal purchasePrice, decimal sellPrice, int quantity, string description, decimal discountPercentage = 0)
        {
            this.Title = title;
            this.AvaragePurchasePricePerUnit = purchasePrice;
            this.SellPrice = sellPrice;
            this.Quantity = quantity;
            this.Description = description;
            this.DiscountPercentage = discountPercentage;
        }

        /// <summary>
        /// Setting a <see cref="Title"/> requires to check is it null, empty string or too short
        /// </summary>
        public string? Title 
        { 
            get => this.title;
            set
            {
                ProductValidations.NullOrEmptyValidation(value);
                ProductValidations.MoreThanFourLettersValidation(value);
                this.title = value;
            }
        }

        /// <summary>
        /// The <see cref="AvaragePurchasePricePerUnit"/> can be set at the begining from the constructor.
        /// Later on can be change only if we add products with different purchase price compared to the current.
        /// We have to check is it a positive number.
        /// </summary>
        public decimal AvaragePurchasePricePerUnit 
        { 
            get => this.avaragePurchasePricePerUnit;
            private set
            {
                ProductValidations.PositiveNumberValidation(value, nameof(AvaragePurchasePricePerUnit));

                this.avaragePurchasePricePerUnit = value;
            }
        }
        
        /// <summary>
        /// <see cref="SellPrice"/> can be set at the beginning from te constroctur or later on.
        /// But we have to be sure that is not only a positive number, but also that we are not selling for less money
        /// that we purhaced the product. With other words - to not sell at loss.
        /// </summary>
        public decimal SellPrice 
        { 
            get => this.sellPrice; 
            set
            {
                ProductValidations.PositiveNumberValidation(value, nameof(SellPrice));
                ProductValidations.UnderPriceFromSellPriceValidation(value, this.AvaragePurchasePricePerUnit);

                this.sellPrice = value;
            }
        }

        /// <summary>
        /// For discount we use absolute amount like 5 which means 5%. We are not writing 0.05 to describe it.
        /// So later we have to consider that when we want to calculate sell price after discount.
        /// <see cref="SellPrice"/> after discount should not be lower than avarage purchase price. 
        /// Because that will mean that we are selling at loss.
        /// </summary>
        public decimal DiscountPercentage 
        { 
            get => this.discountPercentage;
            set
            {
                ProductValidations.PositiveOrZeroNumberValidation(value, nameof(value));
                ProductValidations.NegativeSellPriceFromDiscountValidation(value);
                ProductValidations.UnderPricedFromDiscountValidation(this.SellPrice, value, this.AvaragePurchasePricePerUnit);

                this.discountPercentage = value;
            }
        } 

        /// <summary>
        /// We set <see cref="Quantity"/> from constructor.
        /// Water on we change can change it outside the class only through <see cref="IncreseQuantity(int, decimal)"/> and 
        /// <see cref="ReduceQuantity(int)"/>. Because there are some additional validations and changes that we need to perform.
        /// </summary>
        public int Quantity 
        { 
            get => this.quantity; 
            private set
            {
                ProductValidations.PositiveNumberValidation(value, nameof(Quantity));

                this.quantity = value;
            }
        }

        /// <summary>
        /// Setting a <see cref="Description"/> requires to check is it null, empty string, too short or 
        /// too long through initially defined length of <see cref="MaximumDescriptionLength"/>.
        /// It is the place to describe the product in some details that are not included as a specific fields.
        /// </summary>
        public string? Description 
        { 
            get => this.description;
            set
            {
                ProductValidations.NullOrEmptyValidation(value);
                ProductValidations.MoreThanFourLettersValidation(value);
                ProductValidations.MaximumLenghtValidation(value, MaximumDescriptionLength);

                this.description = value;
            }
        }

        /// <summary>
        /// If <paramref name="purchasePricePerUnit"/> of the newly added stock is different from <see cref="avaragePurchasePricePerUnit"/> 
        /// we need to calculate the new a <see cref="avaragePurchasePricePerUnit"/>.
        /// </summary>
        /// <param name="amount">The quantity of newly purchased stock that we want to add to existing supply</param>
        /// <param name="purchasePricePerUnit">The purchase price of the product for one piece, not for all products in total</param>
        public void IncreseQuantity(int amount, decimal purchasePricePerUnit)
        {
            ProductValidations.PositiveNumberValidation(amount, nameof(amount));
            ProductValidations.PositiveNumberValidation(purchasePricePerUnit, nameof(purchasePricePerUnit));
            
            bool isPurhacePriceChanged = purchasePricePerUnit != this.AvaragePurchasePricePerUnit;
            if (isPurhacePriceChanged)
            {
                ChangeAvaragePricePerUnit(amount, purchasePricePerUnit);
            }

            this.Quantity += amount;
        }

        /// <summary>
        /// Helper method to <see cref="IncreseQuantity"/> which purpose is to extract the logic for changing the <see cref="avaragePurchasePricePerUnit"/> 
        /// when newly added stock is with different purchase price.
        /// </summary>
        private void ChangeAvaragePricePerUnit(int amount, decimal purchasePricePerUnit)
        {
            decimal currentStockTotalPurchasePrice = this.Quantity * this.AvaragePurchasePricePerUnit;
            decimal addedStockTotalPurchasePrice = amount * purchasePricePerUnit;

            decimal totalStockSpending = currentStockTotalPurchasePrice + addedStockTotalPurchasePrice;
            int totalQuantity = this.quantity + amount;

            this.AvaragePurchasePricePerUnit = totalStockSpending / totalQuantity;
        }

        /// <summary>
        /// If current quantity is 10 and amount to reduce is 3 then 10 - 3 = 7
        /// </summary>
        /// <param name="amount">The quantity of sold product that we have to extract from the existing supply</param>
        public void ReduceQuantity(int amount)
        {
            ProductValidations.PositiveNumberValidation(amount, nameof(amount));
            ProductValidations.ReduceUnderZeroValidation(this.Quantity, amount);

            this.quantity -= amount;
        }
    }   
}
