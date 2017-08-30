using System.Collections.Generic;

namespace BloggerDocuments.Prices
{
    public class PricingPlan
    {
        public List<Price> Prices { get; set; }

        public PricingPlan()
        {
            Prices = new List<Price>();
        }
    }
}
