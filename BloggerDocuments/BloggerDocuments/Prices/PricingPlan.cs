using System.Collections.Generic;
using System.Linq;

namespace BloggerDocuments.Prices
{
    public class PricingPlan
    {
        public List<ElementPrice> Prices { get; }

        public PricingPlan(IEnumerable<ElementPrice> prices)
        {
            Prices = prices.ToList();
        }
    }
}