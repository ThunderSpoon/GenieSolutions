namespace GenieSolutionsFramework
{
    public class HomePage
    {
        // Check Title of Home Page.
        public bool Title()
        {
            return Driver.PageTitle.Contains("Intelligent Simplicity");
        }
    }
}
