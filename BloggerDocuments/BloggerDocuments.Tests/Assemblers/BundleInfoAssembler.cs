using System.Collections.Generic;
using BloggerDocuments.Prices.Discounts;
using BloggerDocuments.Products;

namespace BloggerDocuments.Tests.Assemblers
{
    class BundleInfoAssembler
    {
        private readonly Dictionary<string, Product> _products;
        private readonly BundleInfo _bundleInfo;

        public BundleInfoAssembler(Dictionary<string, Product> products)
        {
            _products = products;
            _bundleInfo = new BundleInfo(new List<ProductDiscount>());
        }

        public BundleInfoAssembler AddProduct(string name, decimal quantity, decimal discountValue)
        {
            var product = _products[name];

            _bundleInfo.ProductDiscounts.Add(
                new ProductDiscount(product.Info, quantity, discountValue));

            return this;
        }

        public BundleInfoAssembler AddProduct(string name, decimal discountValue)
        {
            return AddProduct(name, 1, discountValue);
        }

        public BundleInfo Build()
        {
            return _bundleInfo;
        }
    }
}
