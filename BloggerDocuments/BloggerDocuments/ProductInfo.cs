namespace BloggerDocuments
{
    public class ProductInfo
    {
        public ProductId Id { get; set; }

        public string Name { get; set; }

        public ProductInfo(ProductId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
