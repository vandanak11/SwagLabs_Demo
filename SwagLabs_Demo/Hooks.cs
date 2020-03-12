using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using System.IO;
using TechTalk.SpecFlow;

namespace SwagLabs_Demo
{
    [Binding]
    public sealed class Hooks
    {
        private static IWebDriver driver;
                     
        [BeforeTestRun]
        public void BeforeTestRun()
        {
            Console.WriteLine("Before test is run");
            Properties.htmlReporter = new ExtentHtmlReporter(@"C:\Report\SpecFlowReport.html");
            string currentDir = Directory.GetCurrentDirectory();
            var configFile = currentDir.Replace("bin\\Debug", "extent-config.xml");
            Properties.htmlReporter.LoadConfig(configFile);
           // Properties.htmlReporter.LoadConfig("C:\\Users\\vandanak\\source\\repos\\SpecFlowPOC\\SpecFlowPOC\\extent-config.xml");

            Properties.extent = new ExtentReports();
            Properties.extent.AttachReporter(Properties.htmlReporter);
            Properties.extent.AddSystemInfo("Automation Database", "8.1");
            Properties.extent.AddSystemInfo("Browser", "Chrome");
            Properties.extent.AddSystemInfo("Application Under Test (AUT)", "FlightProWeb");
            Properties.extent.AddSystemInfo("Application",  ConfigurationManager.AppSettings["URL"]);

            driver = new ChromeDriver("C:\\Automation_GoogleChromeDriverV2");
            driver.Manage().Window.Maximize();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("After test is run");

            Properties.extent.Flush();
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("Before scenario is run");
#pragma warning disable 0618
            Properties.scenario = Properties.featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("After scenario is run");
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            Console.WriteLine("Before feature is run");
            Properties.featureName = Properties.extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {

            Console.WriteLine("After Step is run");

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

#pragma warning disable 0618
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                {
                    Properties.scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "When")
                {
                    Properties.scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }

                else if (stepType == "Then")
                {
                    Properties.scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }

                else if (stepType == "And")
                    Properties.scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    Properties.scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "When")
                    Properties.scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "Then")
                    Properties.scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "And")
                    Properties.scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }
        }
    }
}
