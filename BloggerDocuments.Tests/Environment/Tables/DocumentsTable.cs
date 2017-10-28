﻿using System;
using System.Collections.Generic;
using System.Linq;
using BloggerDocuments.Database.Entities;
using BloggerDocuments.Tests.Assemblers;
using NSubstitute;

namespace BloggerDocuments.Tests.Environment.Tables
{
    public class DocumentsTable
    {
        private readonly ITestEnvironment _object;
        private static int _currentDocId;

        public List<SalesOrderEntity> SalesOrderEntities { get; }

        public DocumentsTable(ITestEnvironment @object)
        {
            _object = @object;
            SalesOrderEntities = new List<SalesOrderEntity>();
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
                var prodId = _object.Products[item.Name];

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

            _object.SalesOrderEntities.Add(salesOrderEntity.Id);
            _object.SalesOrderRepository.Get(salesOrderEntity.Id).Returns(salesOrderEntity);
        }
    }
}