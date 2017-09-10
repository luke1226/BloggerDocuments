using System.Collections.Generic;
using System.Linq;
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

        public PricingPlan Calculate(IEnumerable<ElementInfo> elements)
        {
            var element = elements.First();
            var price = _priceService.GetPrice(element.ProductId.Value);

            return
                new PricingPlan(
                    new List<ProductPrice>()
                    {
                        new ProductPrice(element.ProductId, price)
                    });
        }
    }
}
