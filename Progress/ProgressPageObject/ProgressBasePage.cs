using OpenQA.Selenium;

internal abstract class ProgressBasePage
{
    protected IWebDriver _driver;

    protected ProgressBasePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public virtual void LoadPage(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    public virtual void Close()
    {
        _driver.Close();
    }
}