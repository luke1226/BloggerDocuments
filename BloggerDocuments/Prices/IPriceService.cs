namespace BloggerDocuments.Prices
{
    public interface IPriceService
    {
        decimal GetPrice(int productId);
    }
}