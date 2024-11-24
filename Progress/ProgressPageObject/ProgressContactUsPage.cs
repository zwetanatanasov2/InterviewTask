using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

internal class ProgressContactUsPage : ProgressBasePage
{
    //List with locators for some of the page elements
    private IWebElement pageTitle => _driver.FindElement(By.XPath("//*[@id='Content_T9E42D5B1001_Col00']//span[text()='Contact Us']"));
    private IWebElement getInTouchSection => _driver.FindElement(By.Id("form--1"));
    private IWebElement businessEmailField => _driver.FindElement(By.Id("Email-1"));
    private IWebElement firstNameField => _driver.FindElement(By.Id("Textbox-1"));
    private IWebElement lastNameField => _driver.FindElement(By.Id("Textbox-2"));
    private IWebElement companyField => _driver.FindElement(By.Id("Textbox-3"));
    private IWebElement productInterestDropDown => _driver.FindElement(By.Id("Dropdown-1"));
    private IWebElement iAmDropDown => _driver.FindElement(By.Id("Dropdown-2"));
    private IWebElement countryTerritoryDropDown => _driver.FindElement(By.Id("Country-1"));
    private IWebElement stateDropDown => _driver.FindElement(By.Id("State-1"));
    private IWebElement industryDropDown => _driver.FindElement(By.Id("TaxonomiesListField-1"));
    private IWebElement phoneField => _driver.FindElement(By.Id("Textbox-5"));
    private IWebElement messageField => _driver.FindElement(By.Id("Textarea-1"));
    private IWebElement contactSalesButton => _driver.FindElement(By.XPath("//*[@id='form--1']//button"));
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

    // List of bool objects about page elements.
    public bool ContactUsPageIsDisplayed => pageTitle.Displayed;

    public bool GetInTouchSectionIsDisplayed => getInTouchSection.Displayed;

    public bool IndustryDropDown => industryDropDown.Displayed;

    public bool StateDropDown => stateDropDown.Displayed;

    public bool PartnersEuropeLinkIsDisplayed => partnersEuropeLink.Displayed;

    public bool PartnersNothAmericaLinkIsDisplayed => partnersNortAmericaLink.Displayed;

    public bool PrivacyPolicyEuropeLinkIsDispalyed => privacyPolicyEuropeLink.Displayed;

    public bool PrivacyPolicyNortAmericaLinkIsDisplayed => privacyPolicyNortAmericaLink.Displayed;

    // List of selected elements.
    private SelectElement selectedPdoructDropDown;
    public SelectElement SelectedPdoructDropDown => selectedPdoructDropDown = new SelectElement(productInterestDropDown);

    private SelectElement selectedCountryDropDown;
    public SelectElement SelectedCountryDropDown => selectedCountryDropDown = new SelectElement(countryTerritoryDropDown);

    private SelectElement selectediAmDropDown;
    public SelectElement SelectediAmDropDown => selectediAmDropDown = new SelectElement(iAmDropDown);

    private SelectElement selectedStateDropDown;
    public SelectElement SelectedStateDropDown => selectedStateDropDown = new SelectElement(stateDropDown);

    private SelectElement selectedIndustryDropDown;
    public SelectElement SelectedIndustryDropDown => selectedIndustryDropDown = new SelectElement(industryDropDown);

    // Methods to click page elements.
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

    public void ClickIndustryDropDown()
    {
        industryDropDown.Click();
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

    // Methods to populate text fields on the page
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
    // Methods to select an option form a drop down by value.
    // Not good solution about the next five methods! Another approach is needed here.
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

        public void SelectValueIndustryDropDown(string option)
    {
        ClickIndustryDropDown();
        IWebElement IndustryOption = _driver.FindElement(By.XPath($"//*[@id='TaxonomiesListField-1']/option[text()='{option}']"));
        IndustryOption.Click();
    }
}