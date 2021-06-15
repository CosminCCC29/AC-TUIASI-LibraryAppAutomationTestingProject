using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ACAutomationTesting.PageObjects.UpdateInfoPage.InputData;
using ACAutomationTesting.WaitStrategy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

/// <summary>
/// Author: Melinte Alexandru-Gicu
/// </summary>
namespace ACAutomationTesting.PageObjects
{
    class AddAddressPage
    {
        private IWebDriver driver;

        public AddAddressPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        
        public By Adresa = By.Id("input-22");
        public IWebElement TxtAdresa => driver.FindElement(Adresa);

        public By Numar = By.Id("input_23");
        public IWebElement TxtNumar => driver.FindElement(Numar);

        public By SalveazaAdresa = By.CssSelector("#dialogContent_31 > form > md-container > button");
        public IWebElement BtnSalveazaAdresa => driver.FindElement(SalveazaAdresa);

        public By ListElement = By.CssSelector("#ul-22 > li");

        public IWebElement BtnListElement => driver.FindElement(ListElement);

        public void AddAddress(NewInfoBo inputData)
        {
            TxtAdresa.Clear();
            TxtAdresa.SendKeys(inputData.Adresa);
            WaitHelpers.WaitForElementToBeVisible(driver, ListElement);
            TxtAdresa.Click();
            BtnListElement.Click();
            

            TxtNumar.Clear();
            TxtNumar.SendKeys(inputData.Numar);
            BtnSalveazaAdresa.Click();
        }
    }
}
