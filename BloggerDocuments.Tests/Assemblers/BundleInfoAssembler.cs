using System.Collections.Generic;
using BloggerDocuments.Prices.Discounts;
using BloggerDocuments.Tests.Environment.Tables;

namespace BloggerDocuments.Tests.Assemblers
{
    public class BundleInfoAssembler
    {
        private readonly ProductsTable _products;
        private readonly BundleInfo _bundleInfo;

        public BundleInfoAssembler(ProductsTable products)
        {
            _products = products;
            _bundleInfo = new BundleInfo(new List<ProductDiscount>());
        }

        public BundleInfoAssembler AddProduct(string name, decimal quantity, decimal discountValue)
        {
            var product = _products.Get(name);

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
