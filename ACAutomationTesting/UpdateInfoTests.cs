
using ACAutomationTesting.PageObjects;
using ACAutomationTesting.PageObjects.UpdateInfoPage;
using ACAutomationTesting.PageObjects.UpdateInfoPage.InputData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;


/// <summary>
/// Author:Dima Raul Andrei
/// </summary>
namespace ACAutomationTesting
{
    [TestClass]
    public class UpdateInfoTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private UpdateProfilePage updatePage;
        private AddAddressPage addressPage;

        private static bool flag = false;

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
            updatePage = new UpdateProfilePage(driver);
            addressPage = new AddAddressPage(driver);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if(flag == true)
            {
                driver.FindElement(By.CssSelector("#tab-content-1 > div > div > div.personal-data__address > div > div > md-list > md-list-item:nth-child(1)")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[contains(@id, 'dialogContent_')]/form/md-container/button[2]")).Click();
            }
            flag = false;
            driver.Quit();
        }

        [TestMethod]
        public void Should_update_info_successfully()
        {
            const string email = "test@yahoo.com";
            const string password = "test1234";

            HomePage homePage = loginPage.LoginUser(email, password);

            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, homePage.siteLogoIdSelector);
            homePage.LoggedUserDOMElement.Click();
            homePage.ProfilePage.Click();
            
            var inputData = new NewInfoBo
            {
                Nume = "Overriden First Name",
                Telefon = "0792929292"
            };
            
            updatePage.SaveInfo(inputData);
            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, updatePage.SalveazaDateleButonInactiv);
        
            Assert.AreEqual("true",updatePage.BtnSalveazaDatele.GetAttribute("disabled"));
        }

        [TestMethod]
        public void Should_change_password_successfully()
        {
            const string email = "test@yahoo.com";
            const string password = "test1234";

            HomePage homePage = loginPage.LoginUser(email, password);

            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, homePage.siteLogoIdSelector);
            homePage.LoggedUserDOMElement.Click();
      
            homePage.ProfilePage.Click();
            var inputData = new NewInfoBo
            {
                OldPass = "test1234",
                NewPass = "test1234", //se modifica pentru test daca se doreste
                ConfirmPass = "test1234",
            };
            updatePage.ChangePass(inputData);
            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, updatePage.ParolaSchimbata);
            Assert.AreEqual("Parola a fost schimbata cu success", updatePage.AlertParolaSchimbata.Text);
        }
        [TestMethod]
        public void Should_fail_changing_password()
        {
            const string email = "test@yahoo.com";
            const string password = "test1234";

            HomePage homePage = loginPage.LoginUser(email, password);

            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, homePage.siteLogoIdSelector);
            homePage.LoggedUserDOMElement.Click();

            homePage.ProfilePage.Click();
            var inputData = new NewInfoBo
            {
                OldPass = "test123",
                NewPass = "12345678",  //se modifica pentru test daca se doreste
                ConfirmPass = "12345678"
            };
            updatePage.ChangePass(inputData);
            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, updatePage.ParolaSchimbata);
            Assert.AreEqual("Parola curenta nu este valida.", updatePage.AlertParolaSchimbata.Text);
        }

        /// <summary>
        /// Author: Melinte Alexandru-Gicu
        /// </summary>
        [TestMethod]
        public void Should_update_date_of_birth_successfully()
        {
            const string email = "test@yahoo.com";
            const string password = "test1234";

            HomePage homePage = loginPage.LoginUser(email, password);

            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, homePage.siteLogoIdSelector);
            homePage.LoggedUserDOMElement.Click();
            homePage.ProfilePage.Click();
            var inputData = new NewInfoBo
            {
                DataNasterii = "1999-10-21"
            };
            
            updatePage.SaveInfo(inputData);
            Thread.Sleep(1000);
            Assert.AreEqual("true", updatePage.BtnSalveazaDatele.GetAttribute("disabled"));
        }

        [TestMethod]
        public void Should_add_address_successfully()
        {
            flag = true;
            const string email = "test@yahoo.com";
            const string password = "test1234";

            HomePage homePage = loginPage.LoginUser(email, password);

            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, homePage.siteLogoIdSelector);
            homePage.LoggedUserDOMElement.Click();

            homePage.ProfilePage.Click();
            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, updatePage.AddAddressButton);
            updatePage.BtnSchimbaAdresa.Click();

            var inputData = new NewInfoBo
            {
                Adresa = "Strada Cerna",
                Numar = "6"
            };


            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, addressPage.Adresa);
            addressPage.AddAddress(inputData);
            Thread.Sleep(1000);
            Assert.IsTrue(driver.FindElement(By.CssSelector("#tab-content-1 > div > div > div.personal-data__address > div > div > md-list > md-list-item:nth-child(1)")).Displayed);
        }
    }
}