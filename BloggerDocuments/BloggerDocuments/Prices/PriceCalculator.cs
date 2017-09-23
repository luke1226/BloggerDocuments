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

        public PricingPlan Calculate(IEnumerable<ElementInfo> elements)
        {
            var bundleStructure = _discountsService.GetBundleStructure();

            var newElements = new List<ElementInfo>(elements);

            BundleInfo bundleInfo = null;

            foreach (var elementInfo in newElements)
            {
                var bundleInfoLocal =
                    bundleStructure
                        .FirstOrDefault(x => x.ProductDiscounts.FirstOrDefault(d => Equals(d.ProductInfo, elementInfo.ProductInfo)) != null);

                if (bundleInfoLocal != null)
                {
                    var hasAllProductsFromBudle = HasAllProductsFromBundle(newElements, bundleInfoLocal);

                    if (hasAllProductsFromBudle)
                    {
                        bundleInfo = bundleInfoLocal;
                        break;
                    }
                }
            }

            if (bundleInfo == null)
                return GetBasicPrices(newElements);

            var priceList = new List<ElementPrice>();

            foreach (var discount in bundleInfo.ProductDiscounts)
            {
                var productIdLocal = discount.ProductInfo;
                var productPrice = _priceService.GetPrice(productIdLocal.Id);

                var elementLocal = newElements.FirstOrDefault(x => x.ProductInfo == productIdLocal);

                if(elementLocal == null)
                    continue;

                priceList.Add(
                    new ElementPrice(elementLocal.ItemId, elementLocal.ProductInfo, productPrice * (1 - discount.Value)));
            }

            return new PricingPlan(priceList);
        }

        private PricingPlan GetBasicPrices(IEnumerable<ElementInfo> elements)
        {
            var priceList = new List<ElementPrice>();

            foreach (var element in elements)
            {
                var productPrice = _priceService.GetPrice(element.ProductInfo.Id);

                priceList.Add(new ElementPrice(element.ItemId, element.ProductInfo, productPrice));
            }

            return new PricingPlan(priceList);
        }

        private bool HasAllProductsFromBundle(IEnumerable<ElementInfo> products, BundleInfo bundleInfo)
        {
            var containsAll = true;

            foreach (var discountForProduct in bundleInfo.ProductDiscounts)
            {
                if (products.FirstOrDefault(x => Equals(x.ProductInfo, discountForProduct.ProductInfo)) == null)
                {
                    containsAll = false;
                    break;
                }
            }

            return containsAll;
        }
    }
}
