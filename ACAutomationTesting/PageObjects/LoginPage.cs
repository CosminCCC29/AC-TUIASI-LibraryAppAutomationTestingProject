using ACAutomationTesting.WaitStrategy;
using OpenQA.Selenium;

namespace ACAutomationTesting.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By emailTextBoxCssSelector = By.CssSelector("input[type=email]");
        private By passwordTextBoxCssSelector = By.CssSelector("input[type=password]");
        private By continueButtonCssSelector = By.CssSelector("button[type=submit]");

        public IWebElement EmailTextBox => driver.FindElement(emailTextBoxCssSelector);
        public IWebElement PasswordTextBox => driver.FindElement(passwordTextBoxCssSelector);
        public IWebElement ContinueButtonTextBox => driver.FindElement(continueButtonCssSelector);

        public HomePage LoginUser(string email, string password)
        {
            WaitHelpers.WaitForElementToBeVisible(driver, continueButtonCssSelector);
            EmailTextBox.SendKeys(email);
            ContinueButtonTextBox.Click();

            WaitHelpers.WaitForElementToBeVisible(driver, continueButtonCssSelector);
            PasswordTextBox.SendKeys(password);
            ContinueButtonTextBox.Click();

            return new HomePage(driver);
        }

        public void EnterEmail(string email)
        {
            WaitHelpers.WaitForElementToBeVisible(driver, continueButtonCssSelector);
            EmailTextBox.SendKeys(email);
            ContinueButtonTextBox.Click();

            WaitHelpers.WaitForElementToBeVisible(driver, continueButtonCssSelector);

        }
    }
}
