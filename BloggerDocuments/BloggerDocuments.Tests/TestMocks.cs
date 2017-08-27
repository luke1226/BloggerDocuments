using System;
using System.Collections.Generic;
using System.Text;
using BloggerDocuments.Prices;
using NSubstitute;

namespace BloggerDocuments.Tests
{
    class TestMocks
    {
        public IPriceService PriceService { get; set; }

        public IPriceCalculator PriceCalculator { get; set; }

        private static TestMocks _instance;
        public static TestMocks Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new TestMocks();

                return _instance;
            }
        }

        private TestMocks()
        {
            PriceService = Substitute.For<IPriceService>();

            PriceCalculator = Substitute.For<IPriceCalculator>();
        }
    }
}
