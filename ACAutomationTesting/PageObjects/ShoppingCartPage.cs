using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace ACAutomationTesting.PageObjects
{
    class ShoppingCartPage
    {
        private IWebDriver driver;

        public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By shoppingCartCssSelector = By.CssSelector("div.checkout-table");
        private By productsCssSelector = By.CssSelector("div.checkout-table__tbody");
        private By productNameCssSelector = By.CssSelector(".prod-name");
        private By productPriceCssSelector = By.CssSelector(".checkout-table__price");

        public ReadOnlyCollection<IWebElement> products => driver.FindElements(productsCssSelector);

        public bool CheckProductInCart(string name, uint grams, uint quantity, float totalToPay)
        {
            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, shoppingCartCssSelector);

            foreach (IWebElement element in products) {

                string productName = element.FindElement(productNameCssSelector).Text;
                float productPrice = float.Parse(element.FindElement(productPriceCssSelector).Text.Replace(" LEI", ""));

                float totalPrice = productPrice * quantity;

                if (productName.Equals($"{name} {grams}g") && totalPrice == totalToPay)
                    return true;
            }

            return false;
        }
    }
}
