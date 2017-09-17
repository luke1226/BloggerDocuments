using System.Linq;
using BloggerDocuments.Database;
using BloggerDocuments.Documents;
using BloggerDocuments.Prices;
using BloggerDocuments.Prices.Discounts;

namespace BloggerDocuments.Factories
{
    public class ReceiptFactory : IReceiptFactory
    {
        public IPriceService PriceService { get; set; }

        public IDiscountsService DiscountsService { get; set; }

        public IReceiptRepository ReceiptRepository { get; set; }

        public ISalesOrderRepository SalesOrderRepository { get; set; }

        public Receipt New()
        {
            return
                new Receipt()
                {
                    PriceCalculator = new PriceCalculator(PriceService, DiscountsService)
                };
        }

        public Receipt GenerateFromSalesOrder(int salesOrderId)
        {
            var salesOrderEntity = SalesOrderRepository.Get(salesOrderId);

            return
                new Receipt()
                {
                    PriceCalculator = new PriceOnlyForNewElementCalculator(PriceService, DiscountsService),
                    Items = salesOrderEntity.Items.Select(e => new ReceiptItem(e)).ToList(),
                    Value = salesOrderEntity.Value  
                };
        }
    }
}
