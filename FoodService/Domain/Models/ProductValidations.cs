namespace FoodService.Domain.Models
{
    public class ProductValidations
    {
        public static void PositiveNumberValidation(decimal number, string paramName)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, "Is not positive number.");
            }
        }
        public static void PositiveNumberValidation(int number, string paramName)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, "Is not positive number.");
            }
        }

        public static void ReduceUnderZeroValidation(int currentQuantity, int reductionAmount)
        {
            if (currentQuantity < reductionAmount)
            {
                throw new ArgumentOutOfRangeException(nameof(reductionAmount), $"{nameof(reductionAmount)} cannot be bigger than  {nameof(currentQuantity)}");
            }
        }

        public static void PositiveOrZeroNumberValidation(decimal number, string paramName)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, $"{paramName} is not positive or zero number.");
            }
        }

        public static void NegativeSellPriceFromDiscountValidation(decimal discountPercentage)
        {
            if (discountPercentage > 100)
            {
                throw new ArgumentOutOfRangeException($"{nameof(discountPercentage)} is making sell price to be a negative number.");
            }
        }
        public static void UnderPricedFromDiscountValidation(decimal sellPrice, decimal discountPercentage, decimal avaragePurchasePricePerUnit)
        {
            bool isUnderPriced = sellPrice * (1 - discountPercentage / 100) < avaragePurchasePricePerUnit;
            if (isUnderPriced)
            {
                throw new ArgumentOutOfRangeException($"{nameof(discountPercentage)} is making {nameof(sellPrice)} lower than {nameof(avaragePurchasePricePerUnit)}.");
            }
        }

        public static void UnderPriceFromSellPriceValidation(decimal newPrice, decimal avaragePurchasePricePerUnit)
        {
            if (newPrice < avaragePurchasePricePerUnit)
            {
                throw new ArgumentOutOfRangeException($"{nameof(newPrice)} is smaller than {nameof(avaragePurchasePricePerUnit)}");
            }
        }

        public static void NullOrEmptyValidation(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException($"Cannot have empty text field.");
            }
        }
        public static void MoreThanFourLettersValidation(string text)
        {
            if (text.Length < 4)
            {
                throw new ArgumentOutOfRangeException($"{text} is less than 4 letters.");
            }
        }
        public static void MaximumLenghtValidation(string text, int maximumLength)
        {
            if (text.Length > maximumLength)
            {
                throw new ArgumentOutOfRangeException($"{text} is more than {maximumLength} letters.");
            }
        }
    }
}
