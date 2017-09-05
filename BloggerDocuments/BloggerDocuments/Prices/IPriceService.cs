namespace BloggerDocuments.Prices
{
    public interface IPriceService
    {
        decimal GetPrice(string productId);
    }
}