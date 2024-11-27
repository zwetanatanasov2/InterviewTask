using OpenQA.Selenium;

internal class ProgressThankYouPage(IWebDriver driver) : ProgressBasePage(driver)
{
    private IWebElement confirmationMessage => _driver.FindElement(By.XPath("//*[@id='Content_C055_Col00']/h1"));

    public override void LoadPage(string url)
    {
        base.LoadPage(url);
        _driver.Manage().Window.Maximize();
    }

    public override void Close()
    {
        base.Close();
    }

    // List of bool objects about page elements.
    public bool IsDisplayedConfirmationMessage => confirmationMessage.Displayed;

    // Methods to return the value form an element.
    public string TakeValueConfirmationMessage()
    {
        string confirmMessafe = confirmationMessage.Text;
        return confirmMessafe;
    }
}