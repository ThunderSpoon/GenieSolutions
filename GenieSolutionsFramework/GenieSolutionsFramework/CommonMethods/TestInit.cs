using NUnit.Framework;

namespace GenieSolutionsFramework
{
    [SetUpFixture]
    public class TestInit
    {
        [OneTimeSetUp]
        public static void Main()
        {
            Driver.Navigation();
        }

        [OneTimeTearDown]
        public static void CleanUp()
        {
            Driver.Close();
        }
    }
}
