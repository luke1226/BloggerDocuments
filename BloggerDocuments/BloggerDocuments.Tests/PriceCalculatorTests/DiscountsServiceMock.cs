using System.Collections.Generic;
using System.Linq;
using BloggerDocuments.Prices.Discounts;

namespace BloggerDocuments.Tests.PriceCalculatorTests
{
    class DiscountsServiceMock : IDiscountsService
    {
        private readonly List<DiscountInfo> _discountStructure;

        public DiscountsServiceMock(IEnumerable<DiscountInfo> discountInfos)
        {
            _discountStructure = discountInfos.ToList();
        }

        public List<DiscountInfo> GetDiscountStructure()
        {
            return _discountStructure;
        }
    }
}
