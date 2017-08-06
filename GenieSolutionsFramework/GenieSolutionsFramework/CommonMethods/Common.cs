using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;

namespace GenieSolutionsFramework
{
    public static class Common
    {
        // Click elements with green highlight.
        public static void Clicks(this IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.Instance;
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, " border: 3px solid green;");

            WaitElements(element);
            element.Click();
        }

        public static void InputText(this IWebElement element, string input)
        {
            element.SendKeys(input);
        }

        public static void HitEnterKey(this IWebElement element)
        {
            element.SendKeys(Keys.Enter);
        }

        public static void CopyText(this IWebElement element)
        {
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Control + "c");
        }

        public static void PasteText(this IWebElement element)
        {
            element.SendKeys(Keys.Control + "v");
        }

        public static void DropDown(this IWebElement element, string Select)
        {
            new SelectElement(element).SelectByText(Select);
        }

        public static void ClearTextBox(this IWebElement element)
        {
            Clicks(element);
            element.Clear();
        }

        public static void WaitElements(this IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        // HIghlight element with red color
        public static void Highlight(this IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.Instance;
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, " border: 5px solid red;");
        }
        // Scroll up or down to element location
        public static void Scroll(this IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.Instance;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void VerifyText(this IWebElement element, string text)
        {
            Assert.IsTrue(element.Text.Equals(text));
            Highlight(element);
        }

        // get element text
        public static string GetText(this IWebElement element)
        {
            var text = element.Text;
            return text;
        }

        //getr total elements count
        public static int GetActualCount(By by)
        {
            int actualResultsCount = 0;
            return actualResultsCount = Driver.Instance.FindElements(by).Count;
        }

        // get int number from string.
        public static int GetNumberFromString(this IWebElement element)
        {
            string Message = GetText(element);
            string takeNumberOut = Regex.Match(Message, @"\d+").Value;

            if(takeNumberOut != "")
            {
                int howManyResults = int.Parse(takeNumberOut);
                return howManyResults;
            }
            return 1;
        }
    }
}
