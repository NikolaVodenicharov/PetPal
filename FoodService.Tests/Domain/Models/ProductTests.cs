using FoodService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FoodService.Tests.Domain.Models
{
    public class ProductTests
    {
        private string title = "Product title";
        private decimal purchasePrice = 10.10m;
        private decimal sellPrice = 20.20m;
        private int quantity = 40;
        private string description = "Product description.";
        private decimal discount = 5;

        [Fact]
        public void CreateProduct_WithNonDefaultDiscount_DataIsRecordedCorrectly()
        {
            //Arrange - Act
            Product product = new(title, purchasePrice, sellPrice, quantity, description, discount);

            //Assert
            Assert.Equal(title, product.Title);
            Assert.Equal(purchasePrice, product.AvaragePurchasePricePerUnit);
            Assert.Equal(sellPrice, product.SellPrice);
            Assert.Equal(quantity, product.Quantity);
            Assert.Equal(description, product.Description);
            Assert.Equal(discount, product.DiscountPercentage);
        }

        [Fact]
        public void SetTitle_WithNull_ShouldThrowException()
        {
            //Arrange
            Product product = CreateProduct();

            //Act-Assert
            Assert.Throws<ArgumentNullException>(() => product.Title = null);
        }

        [Fact]
        public void SetTitle_WithLessThanFourLetters_ShouldThrowException()
        {
            //Arrange
            Product product = CreateProduct();

            //Act-Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.Title = "abc");
        }

        [Fact]
        public void SetSellPrice_ToBeZero_ShouldThrowException()
        {
            //Arrange
            Product product = CreateProduct();

            //Act-Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SellPrice = 0);
        }

        [Fact]
        public void SetSellPrice_ToBeLessThanAvaragePurchasePrice_ShouldThrowException()
        {
            //Arrange
            Product product = CreateProduct();

            //Act-Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SellPrice = product.AvaragePurchasePricePerUnit - 1);
        }

        [Fact]
        public void SetDiscountPercentage_ToBeNegativeNumber_ShouldThrowException()
        {
            //Arrange
            Product product = CreateProduct();

            Assert.Throws<ArgumentOutOfRangeException>(() => product.DiscountPercentage = -1);
        }

        [Fact]
        public void SetDiscountPercentage_ToCreateNegativePurchasePrice_ShouldThrowException()
        {
            //Arrange
            Product product = CreateProduct();

            Assert.Throws<ArgumentOutOfRangeException>(() => product.DiscountPercentage = 110);
        }

        [Fact]
        public void SetDiscountPercentage_ToCreateSellPriceLowerThanPurchasePrice_ShouldThrowException()
        {
            //Arrange
            Product product = CreateProduct();
            var discount = (product.AvaragePurchasePricePerUnit / product.SellPrice) * 100 + 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => product.DiscountPercentage = discount);
        }

        [Fact]
        public void SetDescription_WithNull_ShouldThrowException()
        {
            //Arrange
            Product product = CreateProduct();

            //Act-Assert
            Assert.Throws<ArgumentNullException>(() => product.Description = null);
        }

        [Fact]
        public void SetDescription_WithLessThanFourLetters_ShouldThrowException()
        {
            //Arrange
            Product product = CreateProduct();

            //Act-Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.Description = "abc");
        }

        [Fact]
        public void SetDescription_WithLessThanMaximumLetters_ShouldThrowException()
        {
            //Arrange
            Product product = CreateProduct();

            StringBuilder sb = new StringBuilder();
            var moreThanMaximumLetters = Product.MaximumDescriptionLength  / 10 + 10;
            for (int i = 0; i < moreThanMaximumLetters; i++)
            {
                sb.Append("0123456789");
            }

            //Act-Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.Description = sb.ToString());
        }

        [Fact]
        public void IncreaseQuantity_WithPositiveAmount_ShouldIncreaseQuantity()
        {
            //Arrange
            Product product = CreateProduct();
            var amount = 10;
            var purchasePricePerUnit = this.purchasePrice;

            //Act
            product.IncreseQuantity(amount, purchasePricePerUnit);

            //Assert
            Assert.Equal(this.quantity + amount, product.Quantity);
        }

        [Fact]
        public void IncreaseQuantity_WithDifferentPurchasePrice_ShouldAdjustAvaragePurchasePrice()
        {
            //Arrange
            Product product = CreateProduct();
            var amount = 10;
            var purchasePricePerUnit = this.purchasePrice + 5;

            var oldProductsTotalPurchasePrice = this.quantity * this.purchasePrice;
            var newProductsTotalPurchasePrice = amount * purchasePricePerUnit;
            var increasedQuantity = this.quantity + amount;
            var expectedAvaragePricePerUnit = (oldProductsTotalPurchasePrice + newProductsTotalPurchasePrice) / increasedQuantity ;

            //Act
            product.IncreseQuantity(amount, purchasePricePerUnit);

            //Assert
            Assert.Equal(expectedAvaragePricePerUnit, product.AvaragePurchasePricePerUnit);
        }

        [Fact]
        public void IncreaseQuantity_WithNegativeAmount_ThrowException()
        {
            //Arrange
            Product product = CreateProduct();
            var amount = -1;
            var purchasePricePerUnit = 10;

            //Act - Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.IncreseQuantity(amount, purchasePricePerUnit));
        }

        [Fact]
        public void IncreaseQuantity_WithNegativePurchasePrice_ThrowException()
        {
            //Arrange
            Product product = CreateProduct();
            var amount = 1;
            var purchasePricePerUnit = -10;

            //Act - Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.IncreseQuantity(amount, purchasePricePerUnit));
        }

        [Fact]
        public void ReduceQuantity_ByOne_QuantityIsWithOneLess()
        {
            //Arrange
            Product product = CreateProduct();
            var amount = 1;

            //Act
            product.ReduceQuantity(amount);

            //Assert
            Assert.Equal(quantity - amount, product.Quantity);
        }

        [Fact]
        public void ReduceQuantity_WithNegativeAmount_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            Product product = CreateProduct();
            var amount = -1;

            //Act - Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.ReduceQuantity(amount));
        }

        [Fact]
        public void ReduceQuantity_WithMoreThanAvailableStock_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            Product product = CreateProduct();
            var amount = quantity +1;

            //Act - Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.ReduceQuantity(amount));
        }

        private Product CreateProduct()
        {
            return new(title, purchasePrice, sellPrice, quantity, description);
        }
    }
}
