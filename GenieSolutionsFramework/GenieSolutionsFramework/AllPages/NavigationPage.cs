using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GenieSolutionsFramework
{
    public class NavigationPage
    {
        //Set page obects
        [FindsBy(How = How.LinkText, Using = "Genie Solutions")]
        private IWebElement GenieSoutions { get; set; }

        [FindsBy(How = How.LinkText, Using = "Genie")]
        private IWebElement Genie { get; set; }

        [FindsBy(How = How.LinkText, Using = "Gentu")]
        private IWebElement Gentu { get; set; }

        [FindsBy(How = How.LinkText, Using = "Contact")]
        private IWebElement Contact { get; set; }

        [FindsBy(How = How.Id, Using = "Layer_1")]
        private IWebElement SearchButton { get; set; }


        public void HomeMenu()
        {
            GenieSoutions.Clicks();
        }

        public void GenieMenu()
        {
            Genie.Clicks();
        }
        public void GentuMenu()
        {
            Gentu.Clicks();
        }

        public void ContactMenu()
        {
            Contact.Clicks();
        }

        public void SearchMenu()
        {
            SearchButton.Clicks();       
        }      
    }
}
