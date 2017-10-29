using BloggerDocuments.Factories;
using BloggerDocuments.Tests.Environment.Mocks;

namespace BloggerDocuments.Tests.Environment.Providers
{
    public class DocumentFactoryProvider
    {
        private readonly ITestEnvironment _environment;
        private ITestMocks Mocks => _environment.Mocks;

        public DocumentFactoryProvider(ITestEnvironment environment)
        {
            _environment = environment;
        }

        public IReceiptFactory ReceiptFactory()
        {
            return
                new ReceiptFactory()
                {
                    SalesOrderRepository = Mocks.SalesOrderRepository,
                    DiscountsService = Mocks.DiscountsService,
                    PriceService = Mocks.PriceService,
                    Logger = Mocks.Logger
                };
        }
    }
}
