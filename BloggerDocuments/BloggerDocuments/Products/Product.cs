namespace BloggerDocuments.Products
{
    public class Product
    {
        public ProductId Id { get; set; }

        public string Name { get; set; }

        public Product(ProductId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
