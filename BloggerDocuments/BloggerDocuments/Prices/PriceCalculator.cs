using System;
using System.Collections.Generic;

namespace BloggerDocuments.Prices
{
    public class PriceCalculator : IPriceCalculator
    {
        public PriceList Calculate(Guid productId, decimal quantity, IEnumerable<Guid> existingProducts)
        {
            throw new NotImplementedException();
        }
    }
}
