namespace FoodService.Domain.Models
{
    public class Product
    {
        private string? title;
        private decimal avaragePurchasePricePerUnit;
        private decimal sellPrice;
        private decimal discountPercentage;
        private int quantity;
        private string? description;
     
        public Product(string title, decimal purchasePrice, decimal sellPrice, int quantity, string description, decimal discountPercentage = 0)
        {
            this.Title = title;
            this.AvaragePurchasePricePerUnit = purchasePrice;
            this.SellPrice = sellPrice; // it should be initialized after purchasePrice,  because it is making calulations based on it
            this.Quantity = quantity;
            this.Description = description;
            this.DiscountPercentage = discountPercentage; // it should be initialized after purchasePrice and sellPrice , because it is making calulations based on them
        }

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

        public decimal AvaragePurchasePricePerUnit 
        { 
            get => this.avaragePurchasePricePerUnit;
            private set
            {
                ProductValidations.PositiveNumberValidation(value, nameof(AvaragePurchasePricePerUnit));

                this.avaragePurchasePricePerUnit = value;
            }
        }
        
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
 
        // it could be like 5 (5%), 22 (22%) and so on
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

        public int Quantity 
        { 
            get => this.quantity; 
            private set
            {
                ProductValidations.PositiveNumberValidation(value, nameof(Quantity));

                this.quantity = value;
            }
        }

        public string? Description 
        { 
            get => this.description;
            set
            {
                ProductValidations.NullOrEmptyValidation(value);
                ProductValidations.MoreThanFourLettersValidation(value);

                this.description = value;
            }
        }


        // if purchase price is different we need to change the avarage price per unit
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

            //log for change price or quantity ?
        }
        private void ChangeAvaragePricePerUnit(int amount, decimal purchasePricePerUnit)
        {
            decimal currentStockTotalPurchasePrice = this.Quantity * this.AvaragePurchasePricePerUnit;
            decimal addedStockTotalPurchasePrice = amount * purchasePricePerUnit;

            decimal totalStockSpending = currentStockTotalPurchasePrice + addedStockTotalPurchasePrice;
            int totalQuantity = this.quantity + amount;

            this.AvaragePurchasePricePerUnit = totalStockSpending / totalQuantity;
        }

        // amount is the quantity of the product that we will extract from total quantity
        // if current quantity is 10 and amount to reduce is 3 then 10 - 3 = 7
        public void ReduceQuantity(int amount)
        {
            ProductValidations.PositiveNumberValidation(amount, nameof(amount));
            ProductValidations.ReduceUnderZeroValidation(this.Quantity, amount);

            this.quantity -= amount;
        }
    }   
}
