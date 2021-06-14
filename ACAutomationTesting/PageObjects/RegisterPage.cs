using ACAutomationTesting.WaitStrategy;
using OpenQA.Selenium;

namespace ACAutomationTesting.PageObjects
{
    class RegisterPage
    {
        private IWebDriver driver;

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By newUserCssSelector = By.CssSelector(".login-title-create");
        public IWebElement NewUserLabel => driver.FindElement(newUserCssSelector);

    }
}
