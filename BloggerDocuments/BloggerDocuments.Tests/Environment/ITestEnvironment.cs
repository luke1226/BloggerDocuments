using System;
using System.Collections.Generic;
using BloggerDocuments.Database;
using BloggerDocuments.Logging;
using BloggerDocuments.Prices;
using BloggerDocuments.Prices.Discounts;
using BloggerDocuments.Products;
using BloggerDocuments.Tests.Environment.Providers;

namespace BloggerDocuments.Tests.Environment
{
    public interface ITestEnvironment
    {
        IPriceService PriceService { get; }

        IDiscountsService DiscountsService { get; }

        ISalesOrderRepository SalesOrderRepository { get; }

        ILogger Logger { get; }



        Dictionary<string, Product> Products { get; }

        TestDbObjectList<string, ElementInfo> ElementInfos { get; }

        Dictionary<string, ElementPrice> Prices { get; }

        List<int> SalesOrderEntities { get; }

        DocumentFactoryProvider DocumentFactories { get; }



        ITestEnvironment Create(Action<TestEnvironmentBuilder> context);

        void Add(Action<TestEnvironmentBuilder> context);
    }
}