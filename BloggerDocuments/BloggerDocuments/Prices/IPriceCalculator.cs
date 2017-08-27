using System;
using System.Collections.Generic;

namespace BloggerDocuments.Prices
{
    public interface IPriceCalculator
    {
        PriceList Calculate(Guid productId, decimal quantity, IEnumerable<Guid> existingProducts);
    }
}