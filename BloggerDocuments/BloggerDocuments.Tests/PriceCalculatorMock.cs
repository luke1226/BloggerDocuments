using System;
using System.Collections.Generic;
using BloggerDocuments.Prices;

namespace BloggerDocuments.Tests
{
    class PriceCalculatorMock : IPriceCalculator
    {
        private readonly IPriceService _priceService = TestMocks.Instance.PriceService;

        public PriceList Calculate(Guid productId, decimal quantity, IEnumerable<Guid> existingProducts)
        {
            var price = _priceService.GetPrice(productId);

            return 
                new PriceList()
                {
                    Prices = new List<Price>()
                    {
                        new Price() { ProductId = productId, Value = price }
                    }
                };
        }
    }
}
