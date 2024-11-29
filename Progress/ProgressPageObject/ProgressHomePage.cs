using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

internal class ProgressHomePage(IWebDriver driver) : ProgressBasePage(driver)
{
    //List with locators for some of the page elements
    private IWebElement NavMenubarReadyToTalkLink => _driver.FindElement(By.Id("js-close-focused"));
    private IWebElement NavMenuBarSolutionsOption => _driver.FindElement(By.XPath("//button[text()='Solutions']"));
    private IWebElement ArtificialIntelligenceSolutions => _driver.FindElement(By.XPath("//div/a[text()='Artificial Intelligence']"));
    private IWebElement NavMenuBarProductsOption => _driver.FindElement(By.XPath("//button[text()='Products']"));
    private IWebElement NavMenuBarSupportServicesOption => _driver.FindElement(By.XPath("//button[text()='Support & Services']"));
    private IWebElement NavMenuBarResourcesPption => _driver.FindElement(By.XPath("//button[text()='Resources']"));
    private IWebElement NavMenuBarPartnersOption => _driver.FindElement(By.XPath("//button[text()='Partners']"));
    private IWebElement NavMenuBarCompanyOption => _driver.FindElement(By.XPath("//button[text()='Company']"));
    private IWebElement NavMenubarSearhIcon => _driver.FindElement(By.Id("js-search-trigger"));

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
        NavMenubarReadyToTalkLink.Click();
    }
    public void HoverSolutionsMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(NavMenuBarSolutionsOption).Perform();
    }

    public void ClickArtifitialInteligenceSolutionsOption()
    {
        HoverSolutionsMenuBarOption();
        ArtificialIntelligenceSolutions.Click();
    }

    public void HoverProductsMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(NavMenuBarProductsOption).Perform();
    }

    public void HoverSupportServiceMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(NavMenuBarSupportServicesOption).Perform();
    }

    public void HoverResourcesMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(NavMenuBarResourcesPption).Perform();
    }

    public void HoverPartnersMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(NavMenuBarPartnersOption).Perform();
    }

    public void HoverCompanyMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(NavMenuBarCompanyOption).Perform();
    }

    public void HoverSearhIconMenuBarOption()
    {
        Actions actions = new Actions(_driver);
        actions.MoveToElement(NavMenubarSearhIcon).Perform();
    }

    public void ClikSearhIconMenuBarOption()
    {
        NavMenubarSearhIcon.Click();
    }
}
