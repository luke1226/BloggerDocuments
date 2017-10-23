using System.Collections.Generic;
using BloggerDocuments.Prices;

namespace BloggerDocuments.Tests.PriceCalculatorTests
{
    class ElementInfoComparer : IEqualityComparer<ElementInfo>
    {
        public bool Equals(ElementInfo x, ElementInfo y)
        {
            if (!x.ItemId.Equals(y.ItemId))
                return false;

            if (!x.ProductInfo.Equals(y.ProductInfo))
                return false;

            return true;
        }

        public int GetHashCode(ElementInfo obj)
        {
            return obj.GetHashCode();
        }
    }
}
