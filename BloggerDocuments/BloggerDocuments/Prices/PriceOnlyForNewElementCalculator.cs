using System.Collections.Generic;
using System.Linq;
using BloggerDocuments.Documents;
using BloggerDocuments.Prices.Discounts;

namespace BloggerDocuments.Prices
{
    public class PriceOnlyForNewElementCalculator : IPriceCalculator
    {
        private readonly IPriceService _priceService;
        private readonly IDiscountsService _discountsService;
        private readonly List<ItemId> _oldItems;

        public PriceOnlyForNewElementCalculator(IPriceService priceService, IDiscountsService discountsService,
            IEnumerable<ItemId> oldItemsIds)
        {
            _priceService = priceService;
            _discountsService = discountsService;
            _oldItems = oldItemsIds.ToList();
        }

        public PricingPlan Calculate(IEnumerable<ElementInfo> elements)
        {
            var bundleStructure = _discountsService.GetBundleStructure();

            var newElements = elements.Where(x => !_oldItems.Contains(x.ItemId)).ToList();

            BundleInfo bundleInfo = null;

            foreach (var elementInfo in newElements)
            {
                var bundleInfoLocal =
                    bundleStructure
                        .FirstOrDefault(x => x.ProductDiscounts.FirstOrDefault(d => Equals(d.ProductInfo, elementInfo.ProductInfo)) != null);

                if (bundleInfoLocal != null)
                {
                    bundleInfo = bundleInfoLocal;
                    break;
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

                if (elementLocal == null)
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
    }
}