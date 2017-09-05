using System.Collections.Generic;

namespace BloggerDocuments.Prices
{
    public interface IPriceCalculator
    {
        PricingPlan Calculate(IEnumerable<ElementInfo> elements);
    }
}