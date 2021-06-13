using OpenQA.Selenium;

namespace ACAutomationTesting.PageObjects
{
    class PizzaPage
    {
        private IWebDriver driver;

        public PizzaPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By addToCartButtonCssSelector = By.CssSelector("button[ng-click='addToCart()']");
        private By totalToPayCssSelector = By.CssSelector(".product__summary__total");

        private By pizzaNameCssSelector = By.CssSelector(".product__name");
        private By pizzaGramsCssSelector = By.CssSelector(".product__properties>strong:first-child");

        private By pizzaContainerElementCssSelector = By.CssSelector(".catalog-product");

        public IWebElement TotalToPay => driver.FindElement(totalToPayCssSelector);
        public IWebElement AddToCartButton => driver.FindElement(addToCartButtonCssSelector);

        public void AddPizzaToCart(uint quantity, out float totalPrice)
        {
            totalPrice = 0;
            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, pizzaContainerElementCssSelector);

            string[] text = TotalToPay.Text.Split(' ');
            float price = float.Parse(TotalToPay.Text.Split(' ')[1]);
            totalPrice = price * quantity;

            for (int i = 0; i < quantity; ++i)
                AddToCartButton.Click();
        }

        public void GetPizzaInfo(out string pizzaName, out uint grams)
        {
            pizzaName = driver.FindElement(pizzaNameCssSelector).Text;

            grams = uint.Parse(driver.FindElement(pizzaGramsCssSelector).Text.Replace("g", ""));
        }
    }
}
