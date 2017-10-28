using BloggerDocuments.Factories;

namespace BloggerDocuments.Tests.Environment.Providers
{
    public class DocumentFactoryProvider
    {
        private readonly ITestEnvironment _environment;

        public DocumentFactoryProvider(ITestEnvironment environment)
        {
            _environment = environment;
        }

        public IReceiptFactory ReceiptFactory()
        {
            return
                new ReceiptFactory()
                {
                    SalesOrderRepository = _environment.SalesOrderRepository,
                    DiscountsService = _environment.DiscountsService,
                    PriceService = _environment.PriceService,
                    Logger = _environment.Logger
                };
        }
    }
}
