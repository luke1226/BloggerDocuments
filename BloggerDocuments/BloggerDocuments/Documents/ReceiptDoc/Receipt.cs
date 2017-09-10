using System.Collections.Generic;
using System.Linq;
using BloggerDocuments.Prices;
using BloggerDocuments.Products;

namespace BloggerDocuments.Documents
{
    public class Receipt
    {
        private List<ReceiptItem> Items { get; }

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

            var priceList =
                PriceCalculator.Calculate(
                    Items.Select(x =>
                        new ElementInfo(
                            x.ProductId, 
                            x.Quantity)));

            UpdatePrices(priceList);

            Recalculate();
        }

        private void UpdatePrices(PricingPlan pricingPlan)
        {
            foreach (var price in pricingPlan.Prices)
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
