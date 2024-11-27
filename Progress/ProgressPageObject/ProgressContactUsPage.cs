using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

internal class ProgressContactUsPage(IWebDriver driver) : ProgressBasePage(driver)
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
    private IWebElement validationMessageFirstNameField => _driver.FindElement(By.XPath("//*[@id='C024_Col00']/div/p"));
    private IWebElement validationMessageEmailField => _driver.FindElement(By.XPath("//*[@id='C023_Col01']/div/p"));

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
    public bool IsDisplayedContactUsPage => pageTitle.Displayed;

    public bool IsDisplayedGetInTouchSection => getInTouchSection.Displayed;

    public bool IsDisplayedIndustryDropDown => industryDropDown.Displayed;

    public bool IsDisplayedStateDropDown => stateDropDown.Displayed;

    public bool IsDisplayedPartnersEuropeLink => partnersEuropeLink.Displayed;

    public bool IsDisplayedPartnersNothAmericaLink => partnersNortAmericaLink.Displayed;

    public bool IsDispalyedPrivacyPolicyEuropeLink => privacyPolicyEuropeLink.Displayed;

    public bool IsDisplayedPrivacyPolicyNortAmericaLink => privacyPolicyNortAmericaLink.Displayed;

    public bool IsDisplayedValidationMessageFirstNameField => validationMessageFirstNameField.Displayed;

    public bool IsDisplayedValidationMessageEmailFiled => validationMessageEmailField.Displayed;

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

    private SelectElement selectedPhoneField;
    public SelectElement SelectedPhoneField => selectedPhoneField = new SelectElement(phoneField);

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
    // Methods to select an option from a drop down by value.
    public void SelectValueProductDropDown(string option)
    {
        var selectedProductOption = new SelectElement(productInterestDropDown);
        selectedProductOption.SelectByText(option);
    }

    public void SelectValueCountryDropDown(string option)
    {
        var selectCountryOption = new SelectElement(countryTerritoryDropDown);
        selectCountryOption.SelectByText(option);
    }

    public void SelectValueIAmDropDown(string option)
    {
        var selectedIAmOption = new SelectElement(iAmDropDown);
        selectedIAmOption.SelectByText(option);
    }

    public void SelectValueStateDropDown(string option)
    {
        var selectedStateOption = new SelectElement(stateDropDown);
        selectedStateOption.SelectByText(option);
    }

    public void SelectValueIndustryDropDown(string option)
    {
        var selectedIndustryOption = new SelectElement(industryDropDown);
        selectedIndustryOption.SelectByText(option);
    }

    // Methods to check the fields are empty and dropdown have default value.
    public bool IsFieldEmpty(IWebElement field)
    {
        return string.IsNullOrEmpty(field.GetAttribute("value"));
    }

    public bool IsFirstNameFieldEmpty()
    {
        return IsFieldEmpty(firstNameField);
    }

    public bool IsBusinessEmailFIledEmpty()
    {
        return IsFieldEmpty(businessEmailField);
    }
    public bool IsLastNameFieldEmpty()
    {
        return IsFieldEmpty(lastNameField);
    }

    public bool IsCompanyFieldEmpty()
    {
        return IsFieldEmpty(companyField);
    }

    public bool IsPhoneFieldEmpty()
    {
        return IsFieldEmpty(phoneField);
    }

    public bool IsProductInterestDropDownEmpty()
    {
        return SelectedPdoructDropDown.SelectedOption.Text == "Select product";
    }

    public bool IsCountryTerritoryDropDownEmpty()
    {
        return SelectedCountryDropDown.SelectedOption.Text == "Select country/territory";
    }

    public bool IsiAmDropDownEmpty()
    {
        return SelectediAmDropDown.SelectedOption.Text == "Select company type";
    }

    public bool IsStateDropDownEmpty()
    {
        return SelectedStateDropDown.SelectedOption.Text == "Select:";
    }

    // Methods to return the value form an element.
    public string TakeValueFirstNameField()
    {
        string firstNameFieldValue = firstNameField.Text;
        return firstNameFieldValue;
    }

    public string TakeValueLastNameField()
    {
        string lastNameFieldValue = lastNameField.Text;
        return lastNameFieldValue;
    }

    public string TakeValuePhoneField()
    {
        string phoneFieldValue = phoneField.Text;
        return phoneFieldValue;
    }

    public string TakeValueValidationMessageEmailFied()
    {
        string validationMessageText = validationMessageEmailField.Text;
        return validationMessageText;
    }
}