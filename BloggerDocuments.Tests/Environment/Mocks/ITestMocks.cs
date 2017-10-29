using BloggerDocuments.Database;
using BloggerDocuments.Logging;
using BloggerDocuments.Prices;
using BloggerDocuments.Prices.Discounts;

namespace BloggerDocuments.Tests.Environment.Mocks
{
    public interface ITestMocks
    {
        ILogger Logger { get; }

        IPriceService PriceService { get; }

        IDiscountsService DiscountsService { get; }

        ISalesOrderRepository SalesOrderRepository { get; }
    }
}