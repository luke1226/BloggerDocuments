﻿using System.Collections.Generic;
using BloggerDocuments.Prices.Discounts;

namespace BloggerDocuments.Tests.Assemblers
{
    class DiscountInfoAssembler
    {
        private readonly Dictionary<string, Product> _products;
        private readonly DiscountInfo _discountInfo;

        public DiscountInfoAssembler(Dictionary<string, Product> products)
        {
            _products = products;
            _discountInfo =
                new DiscountInfo()
                {
                    DiscountForProducts = new List<DiscountForProduct>()
                };
        }

        public DiscountInfoAssembler AddProduct(string name, decimal quantity, decimal discountValue)
        {
            var product = _products[name];

            _discountInfo.DiscountForProducts.Add(
                new DiscountForProduct()
                {
                    ProductId = product.Id,
                    Quantity = quantity,
                    Value = discountValue
                });

            return this;
        }

        public DiscountInfoAssembler AddProduct(string name, decimal discountValue)
        {
            return AddProduct(name, 1, discountValue);
        }

        public DiscountInfo Build()
        {
            return _discountInfo;
        }
    }
}