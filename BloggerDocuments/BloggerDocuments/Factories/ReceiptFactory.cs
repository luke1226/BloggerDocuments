using BloggerDocuments.Database;
using BloggerDocuments.Documents;
using BloggerDocuments.Prices;
using BloggerDocuments.Prices.Discounts;

namespace BloggerDocuments.Factories
{
class ReceiptFactory : IReceiptFactory
{
    public IPriceService PriceService { get; set; }

    public IDiscountsService DiscountsService { get; set; }

    public IReceiptRepository ReceiptRepository { get; set; }

    public Receipt New()
    {
        return
            new Receipt()
            {
                PriceCalculator = new PriceCalculator(PriceService, DiscountsService)
            };
    }

    public Receipt Edit(int id)
    {
        var receiptEntity = ReceiptRepository.Get(id);

        return
            new Receipt()
            {
                PriceCalculator = new PriceCalculator(PriceService, DiscountsService),
                Value = receiptEntity.Value,
                NetValue = receiptEntity.NetValue
            };
    }
}
}
