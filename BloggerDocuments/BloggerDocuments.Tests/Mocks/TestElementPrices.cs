using BloggerDocuments.Prices;

namespace BloggerDocuments.Tests.Mocks
{
    class TestElementPrices
    {
        public static ElementPrice Get(ElementInfo element, decimal value)
        {
            return new ElementPrice(element.ItemId, element.ProductInfo, value);
        }
    }
}