using System.Collections.Generic;
using BloggerDocuments.Database;
using BloggerDocuments.Prices;
using BloggerDocuments.Prices.Discounts;
using BloggerDocuments.Products;
using NSubstitute;

namespace BloggerDocuments.Tests.Db
{
    internal class TestDbObject
    {
        public IPriceService PriceService { get; }

        public IDiscountsService DiscountsService { get; set; }

        public ISalesOrderRepository SalesOrderRepository { get; set; }

        public Dictionary<string, Product> Products { get; }

        public TestDbObjectList<string, ElementInfo> ElementInfos { get; }

        public Dictionary<string, ProductPrice> Prices { get; }

        public List<int> SalesOrderEntities { get; }

        public TestDbObject()
        {
            PriceService = Substitute.For<IPriceService>();

            SalesOrderRepository = Substitute.For<ISalesOrderRepository>();

            Products = new Dictionary<string, Product>();

            ElementInfos = new TestDbObjectList<string, ElementInfo>(
                k =>
                {
                    var p = Products[k];
                    return new ElementInfo(p.Id, 1);
                });

            Prices = new Dictionary<string, ProductPrice>();

            SalesOrderEntities = new List<int>();
        }
    }
}