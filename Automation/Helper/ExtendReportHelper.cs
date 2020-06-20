using Automation.Settings;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace Automation.Helper
{
    public class ExtentReportHelper
    {
        protected static string reportsPath = Environment.GetEnvironmentVariable("REPORTS_PATH");
        protected readonly ExtentV3HtmlReporter htmlReporter;
        public AventStack.ExtentReports.ExtentReports extent = new AventStack.ExtentReports.ExtentReports();
        public ExtentTest feature;
        public ExtentTest scenario;
        public ExtentTest step;
        private readonly string reportFullPath;

        public ExtentReportHelper()
        {
            reportFullPath = $"{reportsPath}TestReport_{DateHelper.GetNowDateTimeAsString()}.html";
            htmlReporter = new ExtentV3HtmlReporter(reportFullPath);

            extent.AttachReporter(htmlReporter);
            SetReportSystemInfo();
        }

        private void SetReportSystemInfo()
        {
            OperatingSystem OS = Environment.OSVersion;
            string browserName = Environment.GetEnvironmentVariable("BROWSER_TYPE");

            extent.AddSystemInfo("Operating System: ", OS.ToString());
            extent.AddSystemInfo("Browser: ", browserName);
        }

        public void SetFeature(string featureName)
        {
            feature = extent.CreateTest<Feature>(featureName);
        }

        public void SetScenario(string scenarioName)
        {
            scenario = feature.CreateNode<Scenario>(scenarioName);
        }

        public void AddScreenCapture(string filePath)
        {
            FileHelper.PrintScreen(filePath);
            ScenarioExtensionMethodHelper.AddScreenCaptureFromPath(FileHelper.FullFilePath);
        }

        internal void OpenCreatedReport()
        {
            Process.Start(new ProcessStartInfo(reportFullPath) { UseShellExecute = true });
        }

        public ExtentTest InsertReportingSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext.StepContext.StepInfo.StepDefinitionType == StepDefinitionType.Given)
                return scenario.StepDefinitionGiven(scenarioContext); // extension method
            if (scenarioContext.StepContext.StepInfo.StepDefinitionType == StepDefinitionType.Then)
                return scenario.StepDefinitionThen(scenarioContext); // extension method
            if (scenarioContext.StepContext.StepInfo.StepDefinitionType == StepDefinitionType.When)
                return scenario.StepDefinitionWhen(scenarioContext); // extension method
            else
                return scenario.StepDefinitionGiven(scenarioContext);
        }
    }
}
