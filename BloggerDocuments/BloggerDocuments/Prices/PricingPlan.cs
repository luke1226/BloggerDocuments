using System.Collections.Generic;
using System.Linq;

namespace BloggerDocuments.Prices
{
    public class PricingPlan
    {
        public List<Price> Prices { get; set; }

        public PricingPlan(IEnumerable<Price> prices)
        {
            Prices = prices.ToList();
        }
    }
}
