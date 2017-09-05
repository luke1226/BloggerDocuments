namespace BloggerDocuments.Tests.Db
{
    internal class TestDbContext
    {
        public ProductsTable Products { get; }

        public DiscountStructureTable DiscountStructure { get; }

        public TestDbContext(TestDbObject @object)
        {
            Products = new ProductsTable(@object);
            DiscountStructure = new DiscountStructureTable(@object);
        }
    }
}