using System.Collections.Generic;

namespace BloggerDocuments.Prices
{
    public class PriceList
    {
        public List<Price> Prices { get; set; }

        public PriceList()
        {
            Prices = new List<Price>();
        }
    }
}
