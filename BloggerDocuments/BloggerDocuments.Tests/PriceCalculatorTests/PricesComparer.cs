using System.Collections.Generic;
using BloggerDocuments.Prices;

namespace BloggerDocuments.Tests.PriceCalculatorTests
{
    class PricesComparer : IEqualityComparer<Price>
    {
        public bool Equals(Price x, Price y)
        {
            if (Equals(x.ProductId, y.ProductId)
                &&
                x.Value == y.Value)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(Price obj)
        {
            return obj.GetHashCode();
        }
    }
}