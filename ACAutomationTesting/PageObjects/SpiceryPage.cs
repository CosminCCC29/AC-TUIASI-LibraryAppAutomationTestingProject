using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAutomationTesting.PageObjects
{
    class SpiceryPage
    {
        private IWebDriver driver;

        public SpiceryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By addToCartButtonCssSelector = By.CssSelector("button[ng-click='addToCart()']");
        private By totalToPayCssSelector = By.CssSelector(".product__summary__total");
        private By spiceGramsCssSelector = By.CssSelector(".product__properties>strong:first-child");

        private By spiceNameCssSelector = By.CssSelector(".product__name");

        private By spiceContainerElementCssSelector = By.CssSelector(".catalog-product");

        public IWebElement TotalToPay => driver.FindElement(totalToPayCssSelector);
        public IWebElement AddToCartButton => driver.FindElement(addToCartButtonCssSelector);

        public void AddSpiceToCart(uint quantity, out float totalPrice)
        {
            totalPrice = 0;
            WaitStrategy.WaitHelpers.WaitForElementToBeVisible(driver, spiceContainerElementCssSelector);

            string[] text = TotalToPay.Text.Split(' ');
            float price = float.Parse(TotalToPay.Text.Split(' ')[1]);
            totalPrice = price * quantity;

            for (int i = 0; i < quantity; ++i)
                AddToCartButton.Click();
        }

        public void GetSpiceInfo(out string spiceName, out uint grams)
        {
            spiceName = driver.FindElement(spiceNameCssSelector).Text;

            grams = uint.Parse(driver.FindElement(spiceGramsCssSelector).Text.Replace("g", ""));
        }
    }
}
