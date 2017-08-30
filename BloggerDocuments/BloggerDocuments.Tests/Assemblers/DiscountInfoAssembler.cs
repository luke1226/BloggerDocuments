using System;
using System.Collections.Generic;
using BloggerDocuments.Prices;
using BloggerDocuments.Tests.Db;

namespace BloggerDocuments.Tests.Assemblers
{
    class DiscountInfoAssembler
    {
        private readonly DiscountInfo _discountInfo;

        public DiscountInfoAssembler()
        {
            _discountInfo =
                new DiscountInfo()
                {
                    Products = new List<Product>(),
                    DiscountForProducts = new List<DiscountForProduct>()
                };
        }

        public DiscountInfoAssembler AddProduct(string name, decimal price, decimal discountValue)
        {
            var product = TestDb.Products.Get(name, p => p.WithPrice(price));

            _discountInfo.Products.Add(product);

            _discountInfo.DiscountForProducts.Add(
                new DiscountForProduct()
                {
                    Product = product,
                    Value = discountValue
                });

            return this;
        }

        public DiscountInfo Build()
        {
            return _discountInfo;
        }
    }
}
