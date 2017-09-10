using System.Collections.Generic;
using System.Linq;

namespace BloggerDocuments.Prices.Discounts
{
    public class DiscountInfo
    {
        public List<ProductDiscount> ProductDiscounts { get; }

        public DiscountInfo(IEnumerable<ProductDiscount> productDiscounts)
        {
            ProductDiscounts = productDiscounts.ToList();
        }
    }
}