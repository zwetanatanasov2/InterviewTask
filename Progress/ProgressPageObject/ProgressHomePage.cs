using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

internal class ProgressHomePage : ProgressBasePage
{
    //List with locators for some of the page elements
    private IWebElement nav_Menubar_ReadyToTalk_Link => _driver.FindElement(By.Id("js-close-focused"));
    private IWebElement nav_MenuBar_Solutions_option => _driver.FindElement(By.XPath("//button[text()='Solutions']"));
    private IWebElement ArtificialIntelligence_Solutions => _driver.FindElement(By.XPath("//div/a[text()='Artificial Intelligence']"));
    private IWebElement nav_MenuBar_Products_option => _driver.FindElement(By.XPath("//button[text()='Products']"));
    private IWebElement nav_MenuBar_SupportServices_option => _driver.FindElement(By.XPath("//button[text()='Support & Services']"));
    private IWebElement nav_MenuBar_Resources_option => _driver.FindElement(By.XPath("//button[text()='Resources']"));
    private IWebElement nav_MenuBar_Partners_option => _driver.FindElement(By.XPath("//button[text()='Partners']"));
    private IWebElement nav_MenuBar_Company_option => _driver.FindElement(By.XPath("//button[text()='Company']"));
    private IWebElement nav_Menubar_SearhIcon => _driver.FindElement(By.Id("js-search-trigger"));

    public ProgressHomePage(IWebDriver driver) : base(driver)
    {
    }

    public override void LoadPage(string url)
    {
        base.LoadPage(url);
        _driver.Manage().Window.Maximize();
    }

    public override void Close()
    {
        base.Close();
    }

    public void ClikReadyToTalkLink()
    {
        nav_Menubar_ReadyToTalk_Link.Click();
    }
    public void HoverSolutionsMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(nav_MenuBar_Solutions_option).Perform();
    }

    public void ClickArtifitialInteligenceSolutionsOption()
    {
        HoverSolutionsMenuBarOption();
        ArtificialIntelligence_Solutions.Click();
    }

    public void HoverProductsMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(nav_MenuBar_Products_option).Perform();
    }

    public void HoverSupportServiceMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(nav_MenuBar_SupportServices_option).Perform();
    }

    public void HoverResourcesMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(nav_MenuBar_Resources_option).Perform();
    }

    public void HoverPartnersMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(nav_MenuBar_Partners_option).Perform();
    }

    public void HoverCompanyMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(nav_MenuBar_Company_option).Perform();
    }

    public void HoverSearhIconMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(nav_Menubar_SearhIcon).Perform();
    }

    public void ClikSearhIconMenuBarOption()
    {
        nav_Menubar_SearhIcon.Click();
    }
}
