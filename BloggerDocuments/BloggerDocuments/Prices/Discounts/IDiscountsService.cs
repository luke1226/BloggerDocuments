using System.Collections.Generic;

namespace BloggerDocuments.Prices.Discounts
{
    public interface IDiscountsService
    {
        List<DiscountInfo> GetDiscountStructure();
    }
}
