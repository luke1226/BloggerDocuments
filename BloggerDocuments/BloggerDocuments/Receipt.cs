using System;
using System.Collections.Generic;
using System.Linq;

namespace BloggerDocuments
{
    public class Receipt
    {
        private List<ReceiptItem> Items { get; set; }

        public decimal Value { get; set; }

        public Receipt()
        {
            Items = new List<ReceiptItem>();
        }

        public void AddItem(Product product, decimal quantity = 1)
        {
            var item = new ReceiptItem(product, quantity);
            Items.Add(item);

            Recalculate();
        }

        private void Recalculate()
        {
            Value = Items.Sum(x => x.Value);
        }
    }
}
