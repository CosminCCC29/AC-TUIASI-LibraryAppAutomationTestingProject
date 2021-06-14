

using ACAutomationTesting.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ACAutomationTesting
{
    [TestClass]
    public class LogoutTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;

        [TestInitialize]
        public void TestSetup()
        {
            //open the browser
            driver = new ChromeDriver();
            //maximaze the window
            driver.Manage().Window.Maximize();
            //open app URL
            driver.Navigate().GoToUrl("https://www.mammamia.ro/ro");

            driver.FindElement(By.CssSelector("a.btn-register-modal")).Click();

            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }


        /// <summary>
        /// Author: Radu-andrei Budeanu
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void Should_logout_succesfully()
        {
            const string email = "cosminccc28@gmail.com";
            const string password = "134679852456";

            loginPage.LoginUser(email, password);

            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, homePage.siteLogoIdSelector);
            if (homePage.LoggedUserDOMElement.Displayed)
            {
                homePage.ProfileButton.Click();

                By logoutCssSelector = By.CssSelector("a[href='https://www.mammamia.ro/ro/deconectare']");
                IWebElement LogoutButton = driver.FindElement(logoutCssSelector);

                LogoutButton.Click();

                //aici se arunca exceptie
                Assert.IsTrue(homePage.LoggedUserDOMElement.Displayed);
            }
        }
    }
}
