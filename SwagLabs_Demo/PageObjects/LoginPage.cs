using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabs_Demo.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {            
            this.driver = driver;
            PageFactory.InitElements(driver, this);                  
        }

        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement txtUsername;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "//*[@id='login_button_container']/div/form/input[@type='submit']")]
        private IWebElement btnLogin;

        public void EnterUserName(string userName)
        {
            txtUsername.SendKeys(userName);
        }

        public void ClearUserName()
        {
            txtUsername.Clear();
        }

        public void EnterPassword(string password)
        {
            txtUsername.SendKeys(password);
        }

        public void ClearPassword()
        {
            txtUsername.Clear();
        }

        public void ClickLogin()
        {
            txtUsername.Click();
        }
    }
}
