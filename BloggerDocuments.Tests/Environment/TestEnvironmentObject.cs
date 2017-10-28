using System;
using System.Collections.Generic;
using BloggerDocuments.Database;
using BloggerDocuments.Documents;
using BloggerDocuments.Logging;
using BloggerDocuments.Prices;
using BloggerDocuments.Prices.Discounts;
using BloggerDocuments.Products;
using BloggerDocuments.Tests.Environment.Providers;
using NSubstitute;

namespace BloggerDocuments.Tests.Environment
{
    public class TestEnvironmentObject : ITestEnvironment
    {
        public IPriceService PriceService { get; }

        public IDiscountsService DiscountsService { get; set; }

        public ISalesOrderRepository SalesOrderRepository { get; }

        public ILogger Logger { get; }



        public Dictionary<string, Product> Products { get; }

        public TestDbObjectList<string, ElementInfo> ElementInfos { get; }

        public Dictionary<string, ElementPrice> Prices { get; }

        public List<int> SalesOrderEntities { get; }

        public DocumentFactoryProvider DocumentFactories { get; }



        public TestEnvironmentObject()
        {
            PriceService = Substitute.For<IPriceService>();

            SalesOrderRepository = Substitute.For<ISalesOrderRepository>();

            Logger = Substitute.For<ILogger>();

            Products = new Dictionary<string, Product>();

            ElementInfos = new TestDbObjectList<string, ElementInfo>(
                k =>
                {
                    var p = Products[k];
                    return new ElementInfo(p.Info, ItemId.New(), 1);
                });

            //Prices = new Dictionary<string, ElementPrice>();

            SalesOrderEntities = new List<int>();

            DocumentFactories = new DocumentFactoryProvider(this);
        }



        public ITestEnvironment Create(Action<TestEnvironmentBuilder> context)
        {
            return TestEnvironment.Create(context);
        }

        public void Add(Action<TestEnvironmentBuilder> context)
        {
            var environmentBuilder = new TestEnvironmentBuilder(this);
            context(environmentBuilder);
        }
    }
}