using GenieSolutionsFramework;
using NUnit.Framework;

namespace SearchFeatureTest
{
    [TestFixture]
    public class SearchFeatureTest : TestInit
    {
        [TestCase("GENIE",          TestName = "TC01_SearchFeature_LargeLettersEnter")]
        [TestCase("2017",           TestName = "TC03_SearchFeature_OnlyNumbers")]
        [TestCase("!@#$%^&*",       TestName = "TC04_SearchFeature_SpecialCharacter")] 
        [TestCase("GeniE  GeNtu",   TestName = "TC08_SearchFeature_TwoBlankSpaceWords")]
        [TestCase("  Gen%e",        TestName = "TC09_SearchFeature_FrontTwoBlankSpace")]
        [TestCase("@#$ 50!GhH.",    TestName = "TC10_SearchFeature_NoResultsMessage")]
        [TestCase("<h1>",           TestName = "TC11_SearchFeature_H1Tag")]
        [TestCase("지니",           TestName = "TC12_SearchFeature_KoreanSearch")]

        [Test]
        public void Genie_Solutions_Search_Feature_Test_Enter(string testData)
        {
            Pages.Navigation.SearchMenu();
            Pages.Search.Keyword(testData);
            Pages.Search.FormEnter();

            Pages.Search.CheckResultsMessage(testData);
            Pages.Search.CheckResultsCount();
        }


        [TestCase("gentu",          TestName = "TC02_SearchFeature_SmallLettersClick")]

        [Test]
        public void Genie_Solutions_Search_Feature_Test_Click(string testData)
        {
            Pages.Navigation.SearchMenu();
            Pages.Search.Keyword(testData);
            Pages.Search.ClickSearch();

            Pages.Search.CheckResultsMessage(testData);
            Pages.Search.CheckResultsCount();
        }


        [TestCase("",           TestName = "TC05_SearchFeature_NoInputEnter")]
        [TestCase(" ",          TestName = "TC07_SearchFeature_BlankSpace")]

        [Test]
        public void Genie_Solutions_Search_Feature_NoInputEnter(string testData)
        {
            Pages.Navigation.SearchMenu();
            Pages.Search.Keyword(testData);
            Pages.Search.FormEnter();

            Assert.IsTrue(Pages.Home.Title());
        }


        [TestCase("",           TestName = "TC06_SearchFeature_NoInputClickButton")]

        [Test]
        public void Genie_Solutions_Search_Feature_NoInputClick(string testData)
        {
            Pages.Navigation.SearchMenu();
            Pages.Search.Keyword(testData);
            Pages.Search.ClickSearch();

            Assert.IsTrue(Pages.Home.Title());
        }
    }
}
