using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

internal class ProgressContactUsPage : ProgressBasePage
{
    private WebDriverWait _wait;
    private IJavaScriptExecutor _js;
     
    public ProgressContactUsPage(IWebDriver driver) : base(driver)
    {
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        _js = (IJavaScriptExecutor)driver;
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

    //List with locators for some of the page elements
    private IWebElement PageTitle => _driver.FindElement(By.XPath("//*[@id='Content_T9E42D5B1001_Col00']//span[text()='Contact Us']"));
    private IWebElement GetInTouchSection => _driver.FindElement(By.Id("form--1"));
    private IWebElement BusinessEmailField => _driver.FindElement(By.Id("Email-1"));
    private IWebElement FirstNameField => _driver.FindElement(By.Id("Textbox-1"));
    private IWebElement LastNameField => _driver.FindElement(By.Id("Textbox-2"));
    private IWebElement CompanyField => _driver.FindElement(By.Id("Textbox-3"));
    private IWebElement ProductInterestDropDown => _driver.FindElement(By.Id("Dropdown-1"));
    private IWebElement IAmDropDown => _driver.FindElement(By.Id("Dropdown-2"));
    private IWebElement CountryTerritoryDropDown => _driver.FindElement(By.Id("Country-1"));
    private IWebElement StateDropDown => _driver.FindElement(By.Id("State-1"));
    private IWebElement IndustryDropDown => _driver.FindElement(By.Id("TaxonomiesListField-1"));
    private IWebElement PhoneField => _driver.FindElement(By.Id("Textbox-5"));
    private IWebElement MessageField => _driver.FindElement(By.Id("Textarea-1"));
    private IWebElement ContactSalesButton => _driver.FindElement(By.XPath("//*[@id='form--1']//button"));
    private IWebElement PrivacyPolicyEuropeLink => _driver.FindElement(By.XPath("//*[@id='form--1']/form/div/div[6]/div[1]/label[1]/p/a"));
    private IWebElement PrivacyPolicyNortAmericaLink => _driver.FindElement(By.XPath("//*[@id='form--1']/form/div/div[6]/div[2]/label/p/a[2]"));
    private IWebElement PartnersEuropeLink => _driver.FindElement(By.XPath("//*[@id='form--1']/form/div/div[6]/div[2]/label/p/a[1]"));
    private IWebElement PartnersNortAmericaLink => _driver.FindElement(By.XPath("//*[@id='form--1']/form/div/div[6]/div[1]/label[2]/p/a[1]"));
    private IWebElement AgreeNotificationsCheckbox => _driver.FindElement(By.CssSelector("input.js-i-agree-checkbox"));
    private IWebElement ValidationMessageFirstNameField => _driver.FindElement(By.XPath("//*[@id='C024_Col00']/div/p"));
    private IWebElement ValidationMessageEmailField => _driver.FindElement(By.XPath("//*[@id='C023_Col01']/div/p"));
    private IWebElement CounterMessageFiled => _driver.FindElement(By.XPath("//*[@id='C026_Col01']/div/div/div/span[2]"));

    // List of bool objects about page elements.
    public bool IsDisplayedContactUsPage => PageTitle.Displayed;
 
    public bool IsDisplayedGetInTouchSection => GetInTouchSection.Displayed;

    public bool IsDisplayedIndustryDropDown => IndustryDropDown.Displayed;

    public bool IsDisplayedStateDropDown => StateDropDown.Displayed;

    public bool IsDisplayedPartnersEuropeLink => PartnersEuropeLink.Displayed;

    public bool IsDisplayedPartnersNothAmericaLink => PartnersNortAmericaLink.Displayed;

    public bool IsDispalyedPrivacyPolicyEuropeLink => PrivacyPolicyEuropeLink.Displayed;

    public bool IsDisplayedPrivacyPolicyNortAmericaLink => PrivacyPolicyNortAmericaLink.Displayed;

    public bool IsDisplayedValidationMessageFirstNameField => ValidationMessageFirstNameField.Displayed;

    public bool IsDisplayedValidationMessageEmailFiled => ValidationMessageEmailField.Displayed;

    public bool IsDisplayedCounterMessageFiled => CounterMessageFiled.Displayed;

    // List of selected elements.
    private SelectElement? selectedPdoructDropDown;
    public SelectElement SelectedPdoructDropDown => selectedPdoructDropDown = new SelectElement(ProductInterestDropDown);

    private SelectElement? selectedCountryDropDown;
    public SelectElement SelectedCountryDropDown => selectedCountryDropDown = new SelectElement(CountryTerritoryDropDown);

    private SelectElement? selectediAmDropDown;
    public SelectElement SelectediAmDropDown => selectediAmDropDown = new SelectElement(IAmDropDown);

    private SelectElement? selectedStateDropDown;
    public SelectElement SelectedStateDropDown => selectedStateDropDown = new SelectElement(StateDropDown);

    private SelectElement? selectedIndustryDropDown;
    public SelectElement SelectedIndustryDropDown => selectedIndustryDropDown = new SelectElement(IndustryDropDown);

    private SelectElement? selectedPhoneField;

    public SelectElement SelectedPhoneField => selectedPhoneField = new SelectElement(PhoneField);

    // Methods to click page elements.
    public void ClikContactSalesButton()
    {
        var contactSalceButton = _wait.Until(ExpectedConditions.ElementToBeClickable(ContactSalesButton));
        contactSalceButton.Click();
    }

    public void ClickProductDropDown()
    {
        var productInterestDropDown = _wait.Until(ExpectedConditions.ElementToBeClickable(ProductInterestDropDown));
        productInterestDropDown.Click();
    }

    public void ClickIAmDropDown()
    {
        var iAmDropDown = _wait.Until(ExpectedConditions.ElementToBeClickable(IAmDropDown));
        iAmDropDown.Click();
    }

    public void ClickCountryDropDown()
    {
        var countryTerritoryDropDown = _wait.Until(ExpectedConditions.ElementToBeClickable(CountryTerritoryDropDown));
        countryTerritoryDropDown.Click();
    }

    public void ClickStateDropDown()
    {
        var stateDropDown = _wait.Until(ExpectedConditions.ElementToBeClickable(StateDropDown));
        stateDropDown.Click();
    }

    public void ClickIndustryDropDown()
    {
        var industryDropDown = _wait.Until(ExpectedConditions.ElementToBeClickable(IndustryDropDown));
        industryDropDown.Click();
    }

    public void ClickPrivasyPolicyEropeLink()
    {
        var privacyPolicyEuropeLink = _wait.Until(ExpectedConditions.ElementToBeClickable(PrivacyPolicyEuropeLink));
        privacyPolicyEuropeLink.Click();
    }

    public void ClickPrivasyPolicyNortAmericaLink()
    {
        var privacyPolicyNortAmericaLink = _wait.Until(ExpectedConditions.ElementToBeClickable(PrivacyPolicyNortAmericaLink));
        privacyPolicyNortAmericaLink.Click();
    }

    public void ClickPartnersEropeLink()
    {
        var partnersEuropeLink = _wait.Until(ExpectedConditions.ElementToBeClickable(PartnersEuropeLink));
        partnersEuropeLink.Click();
    }

    public void ClickPartnersNortAmericaLink()
    {
        var partnersNortAmericaLink = _wait.Until(ExpectedConditions.ElementToBeClickable(PartnersNortAmericaLink));
        partnersNortAmericaLink.Click();
    }

    public void ClickAgreeNotificationsCheckBox()
    {
        var agreeNotificationsCheckbox = _wait.Until(ExpectedConditions.ElementToBeClickable(AgreeNotificationsCheckbox));
        agreeNotificationsCheckbox.Click();
    }

    // Methods to populate text fields on the page
    public void PopulateFirstName(string firstName)
    {
        if (!string.IsNullOrEmpty(firstName))
        {
            var firstNameField = _wait.Until(ExpectedConditions.ElementToBeClickable(FirstNameField));
            firstNameField.SendKeys(firstName);
        }
        else
        {
            throw new ArgumentException("firstName is null or empty.");
        }
    }

    public void PopulateLastName(string lastName)
    {
        if (!string.IsNullOrEmpty(lastName))
        {
            var lastNameField = _wait.Until(ExpectedConditions.ElementToBeClickable(LastNameField));
            lastNameField.SendKeys(lastName);
        }
        else
        {
            throw new ArgumentException("lastName is null or empty.");
        }
    }

    public void PopulateBusinesEmail(string email)
    {
        if (!string.IsNullOrEmpty(email))
        {
            var businessEmailField = _wait.Until(ExpectedConditions.ElementToBeClickable(BusinessEmailField));
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
            var companyField = _wait.Until(ExpectedConditions.ElementToBeClickable(CompanyField));
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
            var phoneField = _wait.Until(ExpectedConditions.ElementToBeClickable(PhoneField));
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
            var messageField = _wait.Until(ExpectedConditions.ElementToBeClickable(MessageField));
            messageField.SendKeys(message);
        }
        else
        {
            throw new ArgumentException("message is null or empty.");
        }
    }
    
    // Methods to select an option from a drop down by value.
    public void SelectValueProductDropDown(string option)
    {
        var selectedProductOption = new SelectElement(ProductInterestDropDown);
        selectedProductOption.SelectByText(option);
    }

    public void SelectValueCountryDropDown(string option)
    {
        var selectCountryOption = new SelectElement(CountryTerritoryDropDown);
        selectCountryOption.SelectByText(option);
    }

    public void SelectValueIAmDropDown(string option)
    {
        var selectedIAmOption = new SelectElement(IAmDropDown);
        selectedIAmOption.SelectByText(option);
    }

    public void SelectValueStateDropDown(string option)
    {
        var selectedStateOption = new SelectElement(StateDropDown);
        selectedStateOption.SelectByText(option);
    }

    public void SelectValueIndustryDropDown(string option)
    {
        var selectedIndustryOption = new SelectElement(IndustryDropDown);
        selectedIndustryOption.SelectByText(option);
    }

    // Methods to check the fields are empty and dropdown have default value.
    public bool IsFieldEmpty(IWebElement field)
    {
        var fieldElement = _wait.Until(ExpectedConditions.ElementToBeClickable(field));
        string fieldValue = (string)_js.ExecuteScript("return arguments[0].value;", fieldElement);
        return string.IsNullOrEmpty(fieldValue);
    }

    public bool IsFirstNameFieldEmpty()
    {
        return IsFieldEmpty(FirstNameField);
    }

    public bool IsBusinessEmailFIledEmpty()
    {
        return IsFieldEmpty(BusinessEmailField);
    }
    public bool IsLastNameFieldEmpty()
    {
        return IsFieldEmpty(LastNameField);
    }

    public bool IsCompanyFieldEmpty()
    {
        return IsFieldEmpty(CompanyField);
    }

    public bool IsPhoneFieldEmpty()
    {
        return IsFieldEmpty(PhoneField);
    }

    // Default value for Product/Interest drop down is "Select product"
    public bool IsProductInterestDropDownEmpty()
    {
        return SelectedPdoructDropDown.SelectedOption.Text == "Select product";
    }

    // Default value for Country/Territory drop down is "Select country/territory"
    public bool IsCountryTerritoryDropDownEmpty()
    {
        return SelectedCountryDropDown.SelectedOption.Text == "Select country/territory";
    }

    // Default value for I Am drop down is "Select company type"
    public bool IsIAmDropDownEmpty()
    {
        return SelectediAmDropDown.SelectedOption.Text == "Select company type";
    }

    // Default value for State drop down is "Select:"
    public bool IsStateDropDownEmpty()
    {
        return SelectedStateDropDown.SelectedOption.Text == "Select:";
    }

    // Methods to return the value form an element.
    public string TakeValueFirstNameField()
    {
        var firstNameField = _wait.Until(ExpectedConditions.ElementToBeClickable(FirstNameField));
        string firstNameFieldValue = (string)_js.ExecuteScript("return arguments[0].value;", firstNameField);
        return firstNameFieldValue;
    }

    public string TakeValueLastNameField()
    {
        var lastNameField = _wait.Until(ExpectedConditions.ElementToBeClickable(LastNameField));
        string lastNameFieldValue = (string)_js.ExecuteScript("return arguments[0].value;", lastNameField);
        return lastNameFieldValue;
    }

    public string TakeValuePhoneField()
    {
        var phoneField = _wait.Until(ExpectedConditions.ElementToBeClickable(PhoneField));
        string phoneFieldValue = (string)_js.ExecuteScript("return arguments[0].value;", phoneField);
        return phoneFieldValue;
    }

    public string TakeValidationMessageEmailFiedText()
    {
        var validationMessageEmailField = _wait.Until(ExpectedConditions.ElementToBeClickable(ValidationMessageEmailField));
        string validationMessageText = validationMessageEmailField.Text;
        return validationMessageText;
    }

    public string TakeValueMessageFieldCounter()
    {
        var counterMessageField = _wait.Until(ExpectedConditions.ElementToBeClickable(CounterMessageFiled));
        string counterValue = counterMessageField.Text;
        return counterValue;
    }
}