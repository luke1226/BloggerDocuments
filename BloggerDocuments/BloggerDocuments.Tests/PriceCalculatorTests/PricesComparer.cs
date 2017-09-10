using System.Collections.Generic;
using BloggerDocuments.Prices;

namespace BloggerDocuments.Tests.PriceCalculatorTests
{
    class PricesComparer : IEqualityComparer<ProductPrice>
    {
        public bool Equals(ProductPrice x, ProductPrice y)
        {
            if (Equals(x.ProductId, y.ProductId)
                &&
                x.Value == y.Value)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(ProductPrice obj)
        {
            return obj.GetHashCode();
        }
    }
}