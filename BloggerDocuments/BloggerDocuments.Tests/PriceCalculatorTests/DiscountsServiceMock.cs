using System.Collections.Generic;
using System.Linq;
using BloggerDocuments.Prices.Discounts;

namespace BloggerDocuments.Tests.PriceCalculatorTests
{
    class DiscountsServiceMock : IDiscountsService
    {
        private readonly List<BundleInfo> _discountStructure;

        public DiscountsServiceMock(IEnumerable<BundleInfo> discountInfos)
        {
            _discountStructure = discountInfos.ToList();
        }

        public List<BundleInfo> GetBundleStructure()
        {
            return _discountStructure;
        }
    }
}
