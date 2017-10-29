using BloggerDocuments.Database;
using BloggerDocuments.Logging;
using BloggerDocuments.Prices;
using BloggerDocuments.Prices.Discounts;
using NSubstitute;

namespace BloggerDocuments.Tests.Environment.Mocks
{
    class TestMocks : ITestMocks
    {
        public ILogger Logger { get; }

        public IPriceService PriceService { get; }

        public IDiscountsService DiscountsService { get; }

        public ISalesOrderRepository SalesOrderRepository { get; }

        public TestMocks()
        {
            Logger = Substitute.For<ILogger>();
            PriceService = Substitute.For<IPriceService>();
            DiscountsService = Substitute.For<IDiscountsService>();
            SalesOrderRepository = Substitute.For<ISalesOrderRepository>();
        }
    }
}