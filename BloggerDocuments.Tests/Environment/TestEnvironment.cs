using System;
using BloggerDocuments.Tests.Environment.Mocks;
using NSubstitute;

namespace BloggerDocuments.Tests.Environment
{
    public static class TestEnvironment
    {
        public static ITestEnvironment Create(Action<TestEnvironmentCreateContext> context)
        {
            var mocks = new TestMocks();

            var createContextObj = new TestEnvironmentCreateContext(mocks);
            context(createContextObj);

            mocks.DiscountsService.GetBundleStructure()
                .Returns(createContextObj.DiscountStructure.GetDiscountInfos());

            var environmentObject = new TestEnvironmentObject(createContextObj, mocks);

            return environmentObject;
        }
    }
}
