namespace BloggerDocuments.Products
{
    public class Product
    {
        public ProductInfo Info { get; set; }

        public string Name { get; set; }

        public Product(ProductInfo info, string name)
        {
            Info = info;
            Name = name;
        }
    }
}
