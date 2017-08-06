using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace GenieSolutionsFramework
{
    public class SearchPage
    {
        [FindsBy(How = How.Id, Using = "s")]
        private IWebElement SearchForm { get; set; }

        [FindsBy(How = How.Id, Using = "searchsubmit")]
        private IWebElement SearchSubmit { get; set; }

        [FindsBy(How = How.TagName, Using = "h1")]
        private IWebElement SearchResultsMessage { get; set; }

        [FindsBy(How = How.TagName, Using = "h2")]
        private IWebElement SearchResultsCount { get; set; }

        //Search results posts By
        private By AllSearchPosts = By.ClassName("search-post");

        public void Keyword(string data)
        {
            SearchForm.InputText(data);
        }

        public void FormEnter()
        {
            SearchForm.HitEnterKey();
        }

        public void ClickSearch()
        {
            SearchSubmit.Clicks();
        }

        public void CheckResultsMessage(string data)
        {
            string searchResultsMessage = "Search Results for ";

            // Trim white spaces
            string removeWhiteSpaces=data.TrimStart();
            Common.VerifyText(SearchResultsMessage, searchResultsMessage + "\"" + removeWhiteSpaces + "\"" + "");
        }


        public void CheckResultsCount()
        {
            string noResults = "We found no results, please refine your search";
            
            // Get search number from message.
            int howManyResults = 0;
            howManyResults = Common.GetNumberFromString(SearchResultsCount);

            // Get actual search posts number.
            int actualResultsCount = 0;
            actualResultsCount = Common.GetActualCount(AllSearchPosts);

            // No search post results.
            if (actualResultsCount == 0)
            {
                Assert.IsTrue(SearchResultsCount.Text == noResults);
                SearchResultsCount.Highlight();
            }

            // Results compare messages number with actual search posts count.
            else if (actualResultsCount > 0)
            {
                Assert.IsTrue(howManyResults == actualResultsCount);
                SearchResultsCount.Highlight();
            }
        }
    }
}
