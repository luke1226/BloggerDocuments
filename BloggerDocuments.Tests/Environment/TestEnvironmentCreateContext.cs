using BloggerDocuments.Tests.Environment.Mocks;
using BloggerDocuments.Tests.Environment.Tables;

namespace BloggerDocuments.Tests.Environment
{
    public class TestEnvironmentCreateContext
    {
        public ProductsTable Products { get; }

        public DiscountStructureTable DiscountStructure { get; }

        public DocumentsTable Documents { get; }

        public TestEnvironmentCreateContext(ITestMocks mocks)
        {
            Products = new ProductsTable(mocks);
            DiscountStructure = new DiscountStructureTable(Products);
            Documents = new DocumentsTable(Products, mocks);
        }

        public TestEnvironmentCreateContext(ProductsTable productsTable, DiscountStructureTable discountStructureTable, DocumentsTable documentsTable)
        {
            Products = productsTable;
            DiscountStructure = discountStructureTable;
            Documents = documentsTable;
        }
    }
}