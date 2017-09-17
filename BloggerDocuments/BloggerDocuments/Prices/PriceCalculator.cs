using System.Collections.Generic;
using System.Linq;
using BloggerDocuments.Prices.Discounts;

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

        public PricingPlan Calculate(ElementInfo newElement, IEnumerable<ElementInfo> elements)
        {
            var discountStructure = _discountsService.GetDiscountStructure();

            var allElements = new List<ElementInfo>(elements);
            allElements.Add(newElement);

            ElementInfo element = null;
            DiscountInfo discountInfo = null;

            foreach (var elementInfo in allElements)
            {
                var discountInfoLocal =
                    discountStructure
                        .FirstOrDefault(x => x.ProductDiscounts.FirstOrDefault(d => Equals(d.ProductId, elementInfo.ProductId)) != null);

                if (discountInfoLocal != null)
                {
                    discountInfo = discountInfoLocal;
                    element = elementInfo;
                    break;
                }
            }

            if (discountInfo == null)
                return GetBasicPrices(allElements);

            var priceList = new List<ProductPrice>();

            foreach (var discount in discountInfo.ProductDiscounts)
            {
                var productIdLocal = discount.ProductId;
                var productPrice = _priceService.GetPrice(productIdLocal.Value);

                priceList.Add(
                    new ProductPrice(productIdLocal, productPrice * (1 - discount.Value)));
            }

            return new PricingPlan(priceList);
        }

        private PricingPlan GetBasicPrices(IEnumerable<ElementInfo> elements)
        {
            var priceList = new List<ProductPrice>();

            foreach (var element in elements)
            {
                var productPrice = _priceService.GetPrice(element.ProductId.Value);

                priceList.Add(new ProductPrice(element.ProductId, productPrice));
            }

            return new PricingPlan(priceList);
        }

        private bool HasAllProducts(IEnumerable<ElementInfo> products, DiscountInfo discountInfo)
        {
            var containsAll = true;

            foreach (var discountForProduct in discountInfo.ProductDiscounts)
            {
                if (products.FirstOrDefault(x => Equals(x.ProductId, discountForProduct.ProductId)) == null)
                {
                    containsAll = false;
                    break;
                }
            }

            return containsAll;
        }
    }
}
