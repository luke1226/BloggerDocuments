namespace BloggerDocuments.Tests.Assemblers
{
    public class ProductAssembler
    {
        public decimal Price { get; private set; }

        public ProductAssembler WithPrice(decimal price)
        {
            Price = price;
            return this;
        }
    }
}