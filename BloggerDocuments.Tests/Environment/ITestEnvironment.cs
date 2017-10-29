using System;
using System.Collections.Generic;
using BloggerDocuments.Prices;
using BloggerDocuments.Tests.Environment.Mocks;
using BloggerDocuments.Tests.Environment.Providers;

namespace BloggerDocuments.Tests.Environment
{
    public interface ITestEnvironment
    {
        ITestMocks Mocks { get; }



        ProductsProvider Products { get; }

        TestDbObjectList<string, ElementInfo> ElementInfos { get; }

        Dictionary<string, ElementPrice> Prices { get; }

        IReadOnlyCollection<int> SalesOrderEntities { get; }

        DocumentFactoryProvider DocumentFactories { get; }



        ITestEnvironment Create(Action<TestEnvironmentCreateContext> context);

        void Add(Action<TestEnvironmentAddContext> context);
    }
}