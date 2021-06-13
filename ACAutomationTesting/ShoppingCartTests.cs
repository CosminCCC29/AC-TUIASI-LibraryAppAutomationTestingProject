using ACAutomationTesting.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ACAutomationTesting
{
    [TestClass]
    public class ShoppingCartTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private PizzaPage pizzaPage;
        private ShoppingCartPage shoppingCartPage;

        [TestInitialize]
        public void TestSetup()
        {
            //open the browser
            driver = new ChromeDriver();
            //maximaze the window
            driver.Manage().Window.Maximize();
            //open app URL
            driver.Navigate().GoToUrl("https://www.mammamia.ro/ro");

            loginPage = new LoginPage(driver);
            pizzaPage = new PizzaPage(driver);
            shoppingCartPage = new ShoppingCartPage(driver);
        }

        [TestMethod]
        public void Should_Add_To_Cart()
        {
            driver.FindElement(By.CssSelector("a.btn-register-modal")).Click();

            const string email = "cosminccc28@gmail.com";
            const string password = "134679852456";
            loginPage.LoginUser(email, password);

            driver.Navigate().GoToUrl("https://www.mammamia.ro/ro/139/p");

            const int quantity = 2;
            string pizzaName;
            uint pizzaGrams;
            float totalToPay;
            pizzaPage.GetPizzaInfo(out pizzaName, out pizzaGrams);
            pizzaPage.AddPizzaToCart(quantity, out totalToPay);
            
            driver.Navigate().GoToUrl("https://www.mammamia.ro/ro/detalii-comanda");
            bool result = shoppingCartPage.CheckProductInCart(pizzaName, pizzaGrams, quantity, totalToPay);

            Assert.IsTrue(result);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

    }
}
