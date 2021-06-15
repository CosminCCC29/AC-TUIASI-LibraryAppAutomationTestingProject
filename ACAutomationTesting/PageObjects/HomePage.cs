using ACAutomationTesting.WaitStrategy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
        private By userProfilePage = By.CssSelector("li>a[href = 'https://www.mammamia.ro/ro/profilul-meu']");
        private By searchBar = By.CssSelector("#fl-input-0");

        public IWebElement LoggedUserDOMElement => driver.FindElement(loggedUserCssSelector);
        public IWebElement LogoById => driver.FindElement(siteLogoIdSelector);
        public IWebElement Logo => driver.FindElement(siteLogoIdSelector);

        public IWebElement ProfileButton => driver.FindElement(userProfileCssSelector);
        public IWebElement ProfilePage => driver.FindElement(userProfilePage);

        public IWebElement SearchBar => driver.FindElement(searchBar);


        public void EnterSearchBar(string text)
        {
            SearchBar.SendKeys(text);
            
        }
    }
}
