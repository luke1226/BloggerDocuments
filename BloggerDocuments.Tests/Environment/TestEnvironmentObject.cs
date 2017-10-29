using System;
using System.Collections.Generic;
using BloggerDocuments.Documents;
using BloggerDocuments.Prices;
using BloggerDocuments.Tests.Environment.Mocks;
using BloggerDocuments.Tests.Environment.Providers;
using BloggerDocuments.Tests.Environment.Tables;

namespace BloggerDocuments.Tests.Environment
{
    class TestEnvironmentObject : ITestEnvironment
    {
        private readonly ProductsTable _productsTable;



        public ITestMocks Mocks { get; }



        public ProductsProvider Products { get; }

        public TestDbObjectList<string, ElementInfo> ElementInfos { get; }

        public Dictionary<string, ElementPrice> Prices { get; }

        public IReadOnlyCollection<int> SalesOrderEntities { get; }

        public DocumentFactoryProvider DocumentFactories { get; }



        public TestEnvironmentObject(TestEnvironmentCreateContext createContext, ITestMocks mocks)
        {
            _productsTable = createContext.Products;

            ElementInfos = new TestDbObjectList<string, ElementInfo>(
                k =>
                {
                    var p = Products.Get(k);
                    return new ElementInfo(p.Info, ItemId.New(), 1);
                });

            //Prices = new Dictionary<string, ElementPrice>();

            SalesOrderEntities = createContext.Documents.SalesOrderEntities;

            DocumentFactories = new DocumentFactoryProvider(this);

            Products = new ProductsProvider(createContext.Products);

            Mocks = mocks;
        }



        public ITestEnvironment Create(Action<TestEnvironmentCreateContext> context)
        {
            return TestEnvironment.Create(context);
        }

        public void Add(Action<TestEnvironmentAddContext> context)
        {
            var addContextObj = new TestEnvironmentAddContext(_productsTable);
            context(addContextObj);
        }
    }

    public class TestEnvironmentAddContext
    {
        public ProductsTable Products { get; }

        public TestEnvironmentAddContext(ProductsTable products)
        {
            Products = products;
        }
    }
}