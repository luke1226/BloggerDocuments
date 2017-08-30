namespace BloggerDocuments.Tests.Assemblers
{
    internal class ProductAssembler
    {
        public decimal Price { get; private set; }

        public ProductAssembler WithPrice(decimal price)
        {
            Price = price;
            return this;
        }
    }
}