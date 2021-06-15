using ACAutomationTesting.PageObjects;
using ACAutomationTesting.PageObjects.UpdateInfoPage;
using ACAutomationTesting.PageObjects.UpdateInfoPage.InputData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

/// <summary>
/// Author: Melinte Alexandru-Gicu
/// </summary>

namespace ACAutomationTesting
{
    [TestClass]
    public class SearchBarTests
    {
        private IWebDriver driver;
        private HomePage homePage;
        private PizzaPage pizzaPage;

        [TestInitialize]
        public void TestSetup()
        {
            //open the browser
            driver = new ChromeDriver();
            //maximaze the window
            driver.Manage().Window.Maximize();
            //open app URL
            driver.Navigate().GoToUrl("https://www.mammamia.ro/ro");
            
            homePage = new HomePage(driver);
            pizzaPage = new PizzaPage(driver);
        }

        [TestMethod]
        public void Should_search_an_existing_pizza()
        {
            string searchPizzaName = "Pizza Garlic";

            homePage.SearchBar.Click();
            homePage.EnterSearchBar(searchPizzaName);
           
            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, By.CssSelector("#ul-0 > li:nth-child(1)"));
            driver.FindElement(By.CssSelector("#ul-0 > li:nth-child(1)")).Click();

            var pizzaName = pizzaPage.GetPizzaName();

            Assert.AreEqual(searchPizzaName, pizzaName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }


    }

}

