using System;
using System.Collections.Generic;

namespace BloggerDocuments.Prices
{
    public interface IDiscountsService
    {
        List<DiscountInfo> GetDiscountStructure();
    }

    public class DiscountInfo
    {
        public List<Product> Products { get; set; }

        public List<DiscountForProduct> DiscountForProducts { get; set; }
    }

    public class DiscountForProduct
    {
        public Product Product { get; set; }

        public decimal Value { get; set; }
    }
}
