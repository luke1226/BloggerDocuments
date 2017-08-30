using System;
using System.Collections.Generic;
using BloggerDocuments.Prices;

namespace BloggerDocuments.Tests
{
    class PriceCalculatorMock : IPriceCalculator
    {
        private readonly IPriceService _priceService = TestMocks.Instance.PriceService;

        public PricingPlan Calculate(Product product, decimal quantity, IEnumerable<Product> existingProducts)
        {
            var price = _priceService.GetPrice(product.Id);

            return 
                new PricingPlan()
                {
                    Prices = new List<Price>()
                    {
                        new Price() { Product = product, Value = price }
                    }
                };
        }
    }
}
