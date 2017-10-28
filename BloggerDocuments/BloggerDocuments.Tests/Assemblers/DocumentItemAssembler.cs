namespace BloggerDocuments.Tests.Assemblers
{
    public class DocumentItemAssembler
    {
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public decimal Quantity { get; private set; }

        public DocumentItemAssembler WithName(string name)
        {
            Name = name;
            return this;
        }

        public DocumentItemAssembler WithPrice(decimal price)
        {
            Price = price;
            return this;
        }

        public DocumentItemAssembler WithQuantity(decimal quantity)
        {
            Quantity = quantity;
            return this;
        }
    }
}
