using OpenQA.Selenium.Support.PageObjects;

namespace GenieSolutionsFramework
{
    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Driver.Instance, page);
            return page;
        }

        public static NavigationPage Navigation
        {
            get { return GetPage<NavigationPage>(); }
        }
        public static HomePage Home
        {
            get { return GetPage<HomePage>(); }
        }
        public static SearchPage Search
        {
            get { return GetPage<SearchPage>(); }
        }

    }
}
