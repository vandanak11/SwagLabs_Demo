using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SwagLabs_Demo.StepBindings
{
    [Binding]
    class LoginPageSteps
    {
        private IWebDriver driver;

        public LoginPageSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I am in Login Page of SwagLabs Application")]
        public void GivenIamInLoginPageOfSwagLabsApplication()
        {

        }

        [Given(@"I have entered valid User name and Password")]
        public void GivenIHaveEnteredValidUsernameAndPassword()
        {

        }

        [When(@"I click on Login Button")]
        public void WhenIClickOnLoginButton()
        {

        }

        [Then(@"I should be navigated to the home page")]
        public void ThenIShouldBeNavigatedToTheHomePage()
        {

        }
    }
}
