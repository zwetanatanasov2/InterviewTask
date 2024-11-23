using OpenQA.Selenium;

internal class ProgressContactUsPage : ProgressBasePage
{
    //List with locators for some of the page elements
    private IWebElement pageTitle => _driver.FindElement(By.XPath("//*[@id='Content_C036_Col00']/h1[text()='How Can We Help?']"));
    private IWebElement getInTouchSection => _driver.FindElement(By.Id("form--1"));
    private IWebElement productInterestDropDown => _driver.FindElement(By.Id("Dropdown-1"));
    private IWebElement businessEmailField => _driver.FindElement(By.Id("Email-1"));
    private IWebElement firstNameField => _driver.FindElement(By.Id("Textbox-1"));
    private IWebElement lastNameField => _driver.FindElement(By.Id("Textbox-2"));
    private IWebElement companyField => _driver.FindElement(By.Id("Textbox-3"));
    private IWebElement iAmDropDown => _driver.FindElement(By.Id("Dropdown-2"));
    private IWebElement countryTerritoryDropDown => _driver.FindElement(By.Id("Country-1"));
    private IWebElement phoneField => _driver.FindElement(By.Id("Textbox-5"));
    private IWebElement messageField => _driver.FindElement(By.Id("Textarea-1"));
    private IWebElement contactSalesButton => _driver.FindElement(By.XPath("//*[@id='form--1']//button"));
    private IWebElement stateDropDown => _driver.FindElement(By.Id("State-1"));
    private IWebElement privacyPolicyEuropeLink => _driver.FindElement(By.XPath("//*[@id='form--1']/form/div/div[6]/div[1]/label[1]/p/a"));
    private IWebElement privacyPolicyNortAmericaLink => _driver.FindElement(By.XPath("//*[@id='form--1']/form/div/div[6]/div[2]/label/p/a[2]"));
    private IWebElement partnersEuropeLink => _driver.FindElement(By.XPath("//*[@id='form--1']/form/div/div[6]/div[2]/label/p/a[1]"));
    private IWebElement partnersNortAmericaLink => _driver.FindElement(By.XPath("//*[@id='form--1']/form/div/div[6]/div[1]/label[2]/p/a[1]"));
    private IWebElement agreeNotificationsCheckbox => _driver.FindElement(By.CssSelector("input.js-i-agree-checkbox"));

    public ProgressContactUsPage(IWebDriver driver) : base(driver)
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
    public void ClikContactSalesButton()
    {
        contactSalesButton.Click();
    }

    public void ClickProductDropDown()
    {
        productInterestDropDown.Click();
    }

    public void ClickIAmDropDown()
    {
        iAmDropDown.Click();
    }

    public void ClickCountryDropDown()
    {
        countryTerritoryDropDown.Click();
    }

    public void ClickStateDropDown()
    {
        stateDropDown.Click();
    }

    public void ClickPrivasyPolicyEropeLink()
    {
        privacyPolicyEuropeLink.Click();
    }

    public void ClickPrivasyPolicyNortAmericaLink()
    {
        privacyPolicyNortAmericaLink.Click();
    }

    public void ClickPartnersEropeLink()
    {
        partnersEuropeLink.Click();
    }

    public void ClickPartnersNortAmericaLink()
    {
        partnersNortAmericaLink.Click();
    }

    public void ClickAgreeNotificationsCheckBox()
    {
        agreeNotificationsCheckbox.Click();
    }

    public void PopulateFirstName(string firstname)
    {
        if (!string.IsNullOrEmpty(firstname))
        {
            firstNameField.SendKeys(firstname);
        }
        else
        {
            throw new ArgumentException("firstname is null or empty.");
        }
    }

    public void PopulateLastName(string lastname)
    {
        if (!string.IsNullOrEmpty(lastname))
        {
            lastNameField.SendKeys(lastname);
        }
        else
        {
            throw new ArgumentException("lastname is null or empty.");
        }
    }

    public void PopulateBusinesEmail(string email)
    {
        if (!string.IsNullOrEmpty(email))
        {
            businessEmailField.SendKeys(email);
        }
        else
        {
            throw new ArgumentException("email is null or empty.");
        }
    }

    public void PopulateCompanyName(string company)
    {
        if (!string.IsNullOrEmpty(company))
        {
            companyField.SendKeys(company);
        }
        else
        {
            throw new ArgumentException("company is null or empty.");
        }
    }

    public void PopulatePhone(string phone)
    {
        if (!string.IsNullOrEmpty(phone))
        {
            phoneField.SendKeys(phone);
        }
        else
        {
            throw new ArgumentException("phone is null or empty.");
        }
    }

    public void PopulateMessage(string message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            messageField.SendKeys(message);
        }
        else
        {
            throw new ArgumentException("message is null or empty.");
        }
    }
    // Not good solution about the next four methods! Another approach is needed here.
    public void SelectValueProductDropDown(string option)
    {
        ClickProductDropDown();
        IWebElement productOption = _driver.FindElement(By.XPath($"//*[@id='Dropdown-1']/option[text()='{option}']"));
        productOption.Click();
    }

    public void SelectValueCountryDropDown(string option)
    {
        ClickCountryDropDown();
        IWebElement countryOption = _driver.FindElement(By.XPath($"//*[@id='Country-1']/option[text()='{option}']"));
        countryOption.Click();
    }

    public void SelectValueIAmDropDown(string option)
    {
        ClickIAmDropDown();
        IWebElement iAmOption = _driver.FindElement(By.XPath($"//*[@id='Dropdown-2']/option[text()='{option}']"));
        iAmOption.Click();
    }

    public void SelectValueStateDropDown(string option)
    {
        ClickStateDropDown();
        IWebElement StateOption = _driver.FindElement(By.XPath($"//*[@id='State-1']/option[text()='{option}']"));
        StateOption.Click();
    }
}