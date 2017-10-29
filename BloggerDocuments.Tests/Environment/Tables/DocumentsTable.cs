using System;
using System.Collections.Generic;
using System.Linq;
using BloggerDocuments.Database.Entities;
using BloggerDocuments.Tests.Assemblers;
using BloggerDocuments.Tests.Environment.Mocks;
using NSubstitute;

namespace BloggerDocuments.Tests.Environment.Tables
{
    public class DocumentsTable
    {
        private readonly ProductsTable _productsTable;
        private readonly ITestMocks _mocks;
        private static int _currentDocId;

        public List<int> SalesOrderEntities { get; }

        public DocumentsTable(ProductsTable productsTable, ITestMocks mocks)
        {
            _productsTable = productsTable;
            _mocks = mocks;
            SalesOrderEntities = new List<int>();
        }

        public void AddSalesOrder(Action<DocumentAssembler> document)
        {
            var documentAssembler = new DocumentAssembler();
            document(documentAssembler);

            _currentDocId++;

            var items = documentAssembler.DocumentItemAssemblers;

            var salesOrderItems = new List<SalesOrderItemEntity>();
            foreach (var item in items)
            {
                var prodId = _productsTable.Get(item.Name);

                salesOrderItems.Add(
                    new SalesOrderItemEntity()
                    {
                        ProductInfo = prodId.Info,
                        ProductName = item.Name,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        Value = item.Price*item.Quantity
                    });
            }

            var salesOrderEntity = new SalesOrderEntity()
            {
                Id = _currentDocId,
                Items = salesOrderItems,
                Value = salesOrderItems.Sum(x => x.Value)
            };

            SalesOrderEntities.Add(salesOrderEntity.Id);
            _mocks.SalesOrderRepository.Get(salesOrderEntity.Id).Returns(salesOrderEntity);
        }
    }
}