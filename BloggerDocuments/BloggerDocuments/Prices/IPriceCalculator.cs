using System.Collections.Generic;

namespace BloggerDocuments.Prices
{
    public interface IPriceCalculator
    {
        PricingPlan Calculate(ElementInfo newElement, IEnumerable<ElementInfo> elements);
    }
}