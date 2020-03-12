using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabs_Demo.PageObjects
{
    class ProductsPage
    {
        private IWebDriver driver;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='inventory_item']/*/button[@class='btn_primary btn_inventory']")]
        private IWebElement btnAddToCartBackPack;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "//*[@id='login_button_container']/div/form/input[@type='submit']")]
        private IWebElement btnLogin;

    }
}
