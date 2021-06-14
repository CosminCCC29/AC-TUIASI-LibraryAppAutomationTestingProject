using OpenQA.Selenium;

namespace ACAutomationTesting.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By loggedUserCssSelector = By.CssSelector("a[href='https://www.mammamia.ro/ro/profilul-meu']");
        public By siteLogoIdSelector = By.Id("logo-header");
        private By userProfileCssSelector = By.CssSelector(".dropdown-toggle");


        public IWebElement LoggedUserDOMElement => driver.FindElement(loggedUserCssSelector);
        public IWebElement LogoById => driver.FindElement(siteLogoIdSelector);
        public IWebElement Logo => driver.FindElement(siteLogoIdSelector);

        public IWebElement ProfileButton => driver.FindElement(userProfileCssSelector);

    }
}
