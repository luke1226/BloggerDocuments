using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BloggerDocuments.Prices.Discounts
{
    [DebuggerDisplay("Count = {ProductDiscounts.Count}")]
    public class BundleInfo
    {
        public List<ProductDiscount> ProductDiscounts { get; }

        public BundleInfo(IEnumerable<ProductDiscount> productDiscounts)
        {
            ProductDiscounts = productDiscounts.ToList();
        }
    }
}