using System.Collections.Generic;
using System.Linq;
using BloggerDocuments.Prices;

namespace BloggerDocuments
{
    public class Receipt
    {
        private List<ReceiptItem> Items { get; set; }

        public IPriceCalculator PriceCalculator { get; set; }

        public decimal Value { get; set; }

        public Receipt()
        {
            Items = new List<ReceiptItem>();
        }

        public void AddItem(Product product, decimal quantity = 1)
        {
            var item = new ReceiptItem(product, quantity);
            Items.Add(item);

            var priceList = PriceCalculator.Calculate(product.Id, quantity, Items.Select(x => x.ProductId));
            UpdatePrices(priceList);

            Recalculate();
        }

        private void UpdatePrices(PriceList priceList)
        {
            foreach (var price in priceList.Prices)
            {
                var item = Items.FirstOrDefault(x => x.ProductId == price.ProductId);
                if (item == null)
                    continue;

                item.Price = price.Value;
                item.Value = item.Price * item.Quantity;
            }
        }

        private void Recalculate()
        {
            Value = Items.Sum(x => x.Value);
        }
    }
}
