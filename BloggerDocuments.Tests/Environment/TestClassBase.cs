namespace BloggerDocuments.Tests.Environment
{
    public abstract class TestClassBase
    {
        private ITestEnvironment _testEnvironment;

        protected ITestEnvironment TestEnvironment
        {
            get
            {
                if (_testEnvironment == null)
                    _testEnvironment = TestEnvironmentProvider.Empty();

                return _testEnvironment;
            }
        }
    }
}