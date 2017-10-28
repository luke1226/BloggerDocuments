using System;
using BloggerDocuments.Tests.PriceCalculatorTests;

namespace BloggerDocuments.Tests.Environment
{
    public static class TestEnvironment
    {
        public static ITestEnvironment Create(Action<TestEnvironmentBuilder> context)
        {
            var environmentObject = new TestEnvironmentObject();
            var environmentBuilder = new TestEnvironmentBuilder(environmentObject);
            context(environmentBuilder);

            environmentObject.DiscountsService =
                new DiscountsServiceMock(environmentBuilder.DiscountStructure.GetDiscountInfos());

            return environmentObject;
        }
    }
}
