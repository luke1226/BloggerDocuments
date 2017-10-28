using System.Collections.Generic;
using BloggerDocuments.Logging;

namespace BloggerDocuments.Prices
{
    public class LoggingPriceCalculator : IPriceCalculator
    {
        private readonly IPriceCalculator _priceCalculator;
        private readonly ILogger _logger;

        public LoggingPriceCalculator(IPriceCalculator priceCalculator, ILogger logger)
        {
            _priceCalculator = priceCalculator;
            _logger = logger;
        }

        public PricingPlan Calculate(IEnumerable<ElementInfo> elements)
        {
            _logger.Log("Elements:" + elements);
            var pricingPlan = _priceCalculator.Calculate(elements);
            _logger.Log("Pricing plan:" + pricingPlan);
            return pricingPlan;
        }
    }
}