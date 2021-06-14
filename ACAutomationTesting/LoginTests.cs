using ACAutomationTesting.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace ACAutomationTesting
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;


        private RegisterPage registerPage;

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
            registerPage = new RegisterPage(driver);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }


        /// <summary>
        /// Author: Cosmin-Constantin Cojocaru
        /// </summary>
        [TestMethod]
        public void Should_login_successfully()
        {
            const string email = "cosminccc28@gmail.com";
            const string password = "134679852456";

            HomePage homePage = loginPage.LoginUser(email, password);
            
            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, homePage.siteLogoIdSelector);
            Assert.IsTrue(homePage.LoggedUserDOMElement.Displayed);
        }  

        /// <summary>
        /// Author: Cosmin-Constantin Cojocaru
        /// </summary>
        [TestMethod]
        public void Should_fail_login_with_wrong_password()
        {
            const string email = "cosminccc28@gmail.com";
            const string password = "123456789";

            loginPage.LoginUser(email, password);

            Assert.IsTrue(loginPage.PasswordTextBox.Displayed);
        }

        /// <summary>
        /// Author: Radu-Andrei Budeanu
        /// </summary>
        [TestMethod]
        public void Should_fail_login_with_wrong_email()
        {
            const string email = "cosminccc30@gmail.com";

            loginPage.EnterEmail(email);

            Assert.IsTrue(registerPage.NewUserLabel.Displayed);
        }
    }
}