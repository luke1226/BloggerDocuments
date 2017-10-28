using BloggerDocuments.Tests.PriceCalculatorTests;

namespace BloggerDocuments.Tests.Environment
{
    static class TestEnvironmentProvider
    {
        public static ITestEnvironment Empty()
        {
            var configuration = new TestEnvironmentObject();
            var contextObj = new TestEnvironmentBuilder(configuration);

            configuration.DiscountsService =
                new DiscountsServiceMock(contextObj.DiscountStructure.GetDiscountInfos());

            return configuration;
        }
    }
}