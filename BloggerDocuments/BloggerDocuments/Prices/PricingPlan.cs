using System.Collections.Generic;
using System.Linq;

namespace BloggerDocuments.Prices
{
    public class PricingPlan
    {
        public List<ProductPrice> Prices { get; }

        public PricingPlan(IEnumerable<ProductPrice> prices)
        {
            Prices = prices.ToList();
        }
    }
}
