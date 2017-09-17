using System.Collections.Generic;
using BloggerDocuments.Prices.Discounts;

namespace BloggerDocuments.Prices
{
    public class PriceOnlyForNewElementCalculator : IPriceCalculator
    {
        private readonly IPriceService _priceService;
        private readonly IDiscountsService _discountsService;

        public PriceOnlyForNewElementCalculator(IPriceService priceService, IDiscountsService discountsService)
        {
            _priceService = priceService;
            _discountsService = discountsService;
        }

        public PricingPlan Calculate(ElementInfo newElement, IEnumerable<ElementInfo> elements)
        {
            throw new System.NotImplementedException();
        }
    }
}