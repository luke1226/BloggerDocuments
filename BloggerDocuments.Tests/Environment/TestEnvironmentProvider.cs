namespace BloggerDocuments.Tests.Environment
{
    static class TestEnvironmentProvider
    {
        public static ITestEnvironment Empty()
        {
            return TestEnvironment.Create(ctx => { });
        }
    }
}