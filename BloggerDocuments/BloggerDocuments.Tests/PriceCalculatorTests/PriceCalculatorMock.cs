using System.Collections.Generic;
using BloggerDocuments.Prices;

namespace BloggerDocuments.Tests.PriceCalculatorTests
{
    class PriceCalculatorMock : IPriceCalculator
    {
        private readonly IPriceService _priceService;

        public PriceCalculatorMock(IPriceService priceService)
        {
            _priceService = priceService;
        }

        public PricingPlan Calculate(ElementInfo newElement, IEnumerable<ElementInfo> elements)
        {
            var price = _priceService.GetPrice(newElement.ProductId.Value);

            return
                new PricingPlan(
                    new List<ProductPrice>()
                    {
                        new ProductPrice(newElement.ProductId, price)
                    });
        }
    }
}
