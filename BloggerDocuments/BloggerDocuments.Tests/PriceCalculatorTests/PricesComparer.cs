using System.Collections.Generic;
using BloggerDocuments.Prices;

namespace BloggerDocuments.Tests.PriceCalculatorTests
{
    class PricesComparer : IEqualityComparer<ElementPrice>
    {
        public bool Equals(ElementPrice x, ElementPrice y)
        {
            if (Equals(x.ItemId, y.ItemId)
                &&
                x.Value == y.Value)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(ElementPrice obj)
        {
            return obj.GetHashCode();
        }
    }
}