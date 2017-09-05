using System.Collections.Generic;
using BloggerDocuments.Prices;
using BloggerDocuments.Prices.Discounts;
using NSubstitute;

namespace BloggerDocuments.Tests.Db
{
    internal class TestDbObject
    {
        public IPriceService PriceService { get; }

        public IDiscountsService DiscountsService { get; set; }

        public Dictionary<string, Product> Products { get; }

        public TestDbObjectList<string, ProductInfo> ProductInfos { get; }

        public TestDbObjectList<string, ElementInfo> ElementInfos { get; }

        public Dictionary<string, Price> Prices { get; }

        public TestDbObject()
        {
            PriceService = Substitute.For<IPriceService>();

            Products = new Dictionary<string, Product>();

            ProductInfos = new TestDbObjectList<string, ProductInfo>(
                k =>
                {
                    var p = Products[k];
                    return new ProductInfo(p.Id, p.Name);
                });

            ElementInfos = new TestDbObjectList<string, ElementInfo>(
                k =>
                {
                    var p = Products[k];
                    return new ElementInfo(p.Id, 1);
                });

            Prices = new Dictionary<string, Price>();
        }
    }
}