using System.Collections.Generic;
using System.Linq;
using BloggerDocuments.Documents;

namespace BloggerDocuments.Prices
{
    public class PriceOnlyForNewElementCalculator : IPriceCalculator
    {
        private readonly IPriceCalculator _priceCalculator;
        private readonly List<ItemId> _oldItems;

        public PriceOnlyForNewElementCalculator(IPriceCalculator priceCalculator, IEnumerable<ItemId> oldItemsIds)
        {
            _priceCalculator = priceCalculator;
            _oldItems = oldItemsIds.ToList();
        }

        public PricingPlan Calculate(IEnumerable<ElementInfo> elements)
        {
            var newElements = elements.Where(x => !_oldItems.Contains(x.ItemId)).ToList();
            return _priceCalculator.Calculate(newElements);
        }
    }
}