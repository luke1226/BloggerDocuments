using System;

namespace BloggerDocuments.Prices
{
    public interface IPriceService
    {
        decimal GetPrice(Guid productId);
    }
}