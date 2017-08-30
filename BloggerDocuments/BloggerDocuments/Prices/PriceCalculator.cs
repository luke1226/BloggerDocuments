using System.Collections.Generic;
using System.Linq;

namespace BloggerDocuments.Prices
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly IPriceService _priceService;
        private readonly IDiscountsService _discountsService;

        public PriceCalculator(IPriceService priceService, IDiscountsService discountsService)
        {
            _priceService = priceService;
            _discountsService = discountsService;
        }

        public PricingPlan Calculate(Product product, decimal quantity, IEnumerable<Product> existingProducts)
        {
            var discountStructure = _discountsService.GetDiscountStructure();

            var discountInfo =
                discountStructure
                    .FirstOrDefault(x => x.Products.FirstOrDefault(p => p.Id == product.Id) != null);

            var containsAll = true;
            foreach (var p in discountInfo.Products)
            {
                if (p.Id == product.Id)
                    continue;

                if (existingProducts.FirstOrDefault(x => x.Id == p.Id) == null)
                {
                    containsAll = false;
                    break;
                }
            }

            var pricingPlan =
                new PricingPlan()
                {
                    Prices = new List<Price>()
                };

            //foreach (var existingProduct in discountInfo.Products)
            //{
            //    var price = _priceService.GetPrice(existingProduct.Id);
            //}

            return null;
        }
    }
}
