using System;
using BloggerDocuments.Tests.PriceCalculatorTests;

namespace BloggerDocuments.Tests.Db
{
    static class TestDb
    {
        public static TestDbObject Add(Action<TestDbContext> context)
        {
            var configuration = new TestDbObject();
            var contextObj = new TestDbContext(configuration);
            context(contextObj);

            configuration.DiscountsService =
                new DiscountsServiceMock(contextObj.DiscountStructure.GetDiscountInfos());

            return configuration;
        }
    }
}
