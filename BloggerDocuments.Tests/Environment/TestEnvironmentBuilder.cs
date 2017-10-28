using BloggerDocuments.Tests.Environment.Tables;

namespace BloggerDocuments.Tests.Environment
{
    public class TestEnvironmentBuilder
    {
        public ProductsTable Products { get; }

        public DiscountStructureTable DiscountStructure { get; }

        public DocumentsTable Documents { get; }

        public TestEnvironmentBuilder(ITestEnvironment @object)
        {
            Products = new ProductsTable(@object);
            DiscountStructure = new DiscountStructureTable(@object);
            Documents = new DocumentsTable(@object);
        }
    }
}