using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GenieSolutionsFramework
{
    public static class Driver
    {
        public static IWebDriver Instance = new ChromeDriver();
        public static string url="https://www.geniesolutions.com.au/";

        public static void Navigation()
        {
            Instance.Navigate().GoToUrl(url);
            Instance.Manage().Window.Maximize();
        }
        public static string PageTitle
        {
            get { return Instance.Title; }
        }
        public static void Close()
        {
            Instance.Close();
        }
    }
}
