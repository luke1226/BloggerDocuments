using System.Collections.Generic;

namespace BloggerDocuments.Prices
{
    public interface IPriceCalculator
    {
        PricingPlan Calculate(Product product, decimal quantity, IEnumerable<Product> existingProducts);
    }
}