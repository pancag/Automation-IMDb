using Automation.DSL;
using Automation.Helper;
using Automation.Settings;
using AventStack.ExtentReports;
using Microsoft.AspNetCore.Hosting;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static Automation.DriverFactory.Driver;

namespace Automation.Base
{
    [Binding]
    public class BaseTestBDD
    {
        protected static string scenarioTitle;
        protected static string featureTitle;
        public static ExtentReportHelper reportHelper;
        public static string printPath;
        public static IWebDriver driver;
        public static FeatureContext _featureContext;
        public DSLIMDb dlsIMDb = new DSLIMDb();
        private static ExtentTest step;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            new WebHostBuilder().UseEnvironment("Development").UseStartup<Startup>().Build();

            reportHelper = new ExtentReportHelper();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _featureContext = featureContext;
            featureTitle = featureContext.FeatureInfo.Title;
            reportHelper.SetFeature(featureTitle);
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            scenarioTitle = scenarioContext.ScenarioInfo.Title;
            printPath = featureTitle + "\\" + scenarioTitle;

            reportHelper.SetScenario(scenarioTitle);
        }

        [BeforeStep]
        public static void BeforeStep(ScenarioContext scenarioContext)
        {
            step = reportHelper.InsertReportingSteps(scenarioContext);
        }

        [AfterTestRun]
        //public static async Task AfterTestRun()
        public static void AfterTestRun()
        {
            //Open report after test run
            reportHelper.OpenCreatedReport(); 
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            //writes the test report
            reportHelper.extent.Flush();
            
            QuitDriver();
        }

        [AfterStep]
        public static void AfterStep(ScenarioContext scenarioContext)
        {
            ScenarioExtensionMethodHelper.UpdateScenario(scenarioContext, step);
        }
    }
}
